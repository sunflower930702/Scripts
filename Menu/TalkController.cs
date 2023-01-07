using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using System.Linq;

public class AnswerData {

    private string answerText;
    private int jumpNo;

    public string AnswerText {
        set {this.answerText = value;}
        get {return this.answerText;}
    }
    public int JumpNo {
        set {this.jumpNo = value;}
        get {return this.jumpNo;}
    }

}


public class TalkController : MonoBehaviour
{

    private PlayerModel playerModel;
    private TalkModel talkModel;

    private TalkNPCData curTalkData;

    public GameObject talkPrefab;

    private bool isActive = false;


    /// ==================================================
    /// Publicメソッド
    /// ==================================================

    public void initTalkMenu(TalkNPCData npcData, bool isRefPlayer) {

        isActive = true;
        this.curTalkData = npcData;

        if (isRefPlayer) {
            playerModel = GameObject.Find(CommonDefine.PLAYER_NAME).GetComponent<PlayerModel>();
        }

        talkModel = initTalk(isRefPlayer);

        CommonModel commonModel = new CommonModel();
        List<string[]> talkList = commonModel.getCsvArray(npcData.TalkFile, true);

        // 会話実行
        StartCoroutine(startTalk(talkList, 1));
    }


    public IEnumerator startTalk(List<string[]> talkList, int startIndex) {

        int talkSize = talkList.Count;
        for(int i = startIndex; i < talkSize; i++) {

            string talkStr = talkList[i][0];
            switch (talkStr) {
                case "question":

                    talkModel.setTalk(talkList[i][1]);
                    yield return new WaitForSeconds(1.0f);


                    int questionTalkListCount = talkList[i].Length;

                    List<AnswerData> answerDataList = new List<AnswerData>();

                    for (int j = 2; j < questionTalkListCount; j++) {
                        AnswerData tmpAnswerData = new AnswerData();

                        tmpAnswerData.AnswerText = talkList[i][j++];
                        tmpAnswerData.JumpNo = int.Parse(talkList[i][j]);

                        answerDataList.Add(tmpAnswerData);
                    }

                    talkModel.setAnswer(answerDataList);
                    yield return new WaitUntil(() => talkModel.checkAnswer());

                    AnswerData ans = talkModel.getAnswer();
                    i = ans.JumpNo - 1;

                    talkModel.closeAnswer();
                    break;
                case "jump":

                    i = int.Parse(talkList[i][1]) - 1;
                    break;
                case "join":

                    talkModel.setCharacter(int.Parse(talkList[i][1]));
                    break;
                case "shop":

                    talkModel.setShopTalkFile(curTalkData.ShopTalkFile);
                    talkModel.setNPCHaveItemList(curTalkData.HaveItemList);
                    talkModel.setShop();
                    yield return new WaitUntil(() => talkModel.checkFinishShop());
                    talkModel.closeShop();
                    break;
                case "quest":

                    if (playerModel != null) {
                        playerModel.addQuest(int.Parse(talkList[i][1]));
                    }
                    break;
                case "backImageON":

                    talkModel.setBackGroundImage(talkList[i][1]);
                    break;
                case "backImageOFF":

                    talkModel.setBackGroundImage(CommonDefine.NULL_IMAGE_PATH);
                    break;
                case "add":

                    string tmpAddText = "";
                    foreach (string txt in talkList[++i]) {
                        tmpAddText = tmpAddText + txt + "\n";
                    }

                    talkModel.addTalk(tmpAddText);
                    yield return new WaitForSeconds(0.8f);
                    talkModel.setNextIcon();
                    yield return new WaitForSeconds(0.2f);
                    yield return new WaitUntil(() => Mouse.current.leftButton.wasPressedThisFrame);
                    talkModel.closeNextIcon();
                    break;
                case "scene":

                    SceneManager.LoadScene(talkList[i][1]);
                    break;
                case "keep":

                    string tmpKeepText = "";
                    var tmpTalkList = (talkList[i]).ToList();
                    tmpTalkList.RemoveAt(0);
                    talkList[i] = tmpTalkList.ToArray();
                    foreach (string txt in talkList[i]) {
                        tmpKeepText = tmpKeepText + txt + "\n";
                    }

                    talkModel.setTalk(tmpKeepText);
                    talkModel.deleteBackPanel();
                    break;
                case "end":

                    closeTalkMenu();
                    yield break;
                default:

                    string tmpText = "";
                    foreach (string txt in talkList[i]) {
                        tmpText = tmpText + txt + "\n";
                    }

                    talkModel.setTalk(tmpText);
                    yield return new WaitForSeconds(0.8f);
                    talkModel.setNextIcon();
                    yield return new WaitForSeconds(0.2f);
                    yield return new WaitUntil(() => Mouse.current.leftButton.wasPressedThisFrame);
                    talkModel.closeNextIcon();
                    break;
            }
        }
    }

    public void closeTalkMenu() {

        Destroy(talkModel.gameObject);

        isActive = false;

        if (playerModel != null) {
            playerModel.GetComponent<PlayerController>().canMenu = true;
        }
    }

    public bool checkIsActive() {
        return isActive;
    }


    /// ==================================================
    /// Privateメソッド
    /// ==================================================

    private TalkModel initTalk(bool isRefPlayer) {

        // Talkメニューを生成
        GameObject talkObj = Instantiate(talkPrefab);
        TalkModel tmpTalkModel = talkObj.GetComponent<TalkModel>();
        tmpTalkModel.changeTalkSize(TalkMenuSize.Large);
        tmpTalkModel.init(isRefPlayer);

        return tmpTalkModel;
    }
}
