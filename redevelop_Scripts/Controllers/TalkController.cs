using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using System.Linq;

/// <summary>
///     会話を扱うコントローラ
/// </summary>
public class TalkController : MonoBehaviour
{

    /// ==================================================
    /// Members
    /// ==================================================

    // 別オブジェクトへの参照
    // Controllers
    public ShopController shopController;

    // Views
    public TalkWindowView talkWindowView;

    // Models
    public InputModel inputModel;
    public NpcModel npcModel;

    // Prefabs
    public GameObject talkWindowPrefab;

    /// <summary>
    ///     表示中の会話ウィンドウ
    /// </summary>
    public GameObject talkWindow;


    /// ==================================================
    /// Public method
    /// ==================================================

    /// <summary>
    ///     会話ウィンドウを表示
    /// </summary>
    public void Talk(NpcController talker) {

        // 会話情報取得
        NpcTalkData npcTalkData = talker.GetNpcTalkData();

        // 会話ウィンドウ作成
        this.CreateWindow();

        // 会話実行
        StartCoroutine(this.ExecTalk(npcTalkData, 1));
    }

    /// <summary>
    ///     会話ウィンドウが表示中かを返す
    /// </summary>
    public bool IsActiveTalkWindow() {
        return (this.talkWindow != null);
    }


    /// ==================================================
    /// Private method
    /// ==================================================

    /// <summary>
    ///     会話ウィンドウを作成
    /// </summary>
    private void CreateWindow() {

        GameObject obj = Instantiate(talkPrefab);
        this.talkWindow = obj;
    }

    /// <summary>
    ///     会話ウィンドウを削除
    /// </summary>
    private void DeleteWindow() {

        Destroy(this.talkWindow);
    }

    /// <summary>
    ///     会話実行
    /// </summary>
    private IEnumerator ExecTalk(NpcTalkData npcTalkData, int startIndex) {

        List<string[]> talkList = CommonModel.GetCsvArray(npcTalkData.TalkFile, true);
        int talkLines = talkList.Count;

        for(int i = startIndex; i < talkLines; i++) {

            string talkStr = talkList[i][0];

            switch (talkStr) {
                // 選択肢
                case "question":

                    // 質問文表示
                    talkWindowView.SetTalkStr(talkList[i][1]);
                    yield return new WaitForSeconds(1.0f);

                    // 回答表示
                    int answerCount = talkList[i].Length;
                    for (int j = 2; j < answerCount; j++) {
                        talkWindowView.talkAnswerWindowView.AddAnswer(talkList[i][j++], int.Parse(talkList[i][j]));
                    }
                    talkWindowView.talkAnswerWindowView.ShowAnswers();
                    yield return new WaitUntil(() => talkWindowView.talkAnswerWindowView.IsGetAnswer());

                    // 回答でループカウントを上書き
                    i = talkWindowView.talkAnswerWindowView.GetAnswer();
                    // 回答非表示
                    talkWindowView.talkAnswerWindowView.ClearAnswer();
                    break;
                // ジャンプ
                case "jump":

                    // ループカウント上書き
                    i = int.Parse(talkList[i][1]) - 1;
                    break;
                // 会話キャラ変更
                case "join":

                    NpcRecordData joinNpcData = npcModel.GetNpcData(int.Parse(talkList[i][1]));
                    talkWindowView.talkCharacterView.SetNpcIllust(joinNpcData.NPCIllustPath);
                    break;
                // ショップ開始
                case "shop":

                    // 会話実行

                    yield return new WaitUntil(() => shopController.IsActiveShopkWindow());

                    break;
                // クエスト受注
                case "quest":

                    // TODO Playerにクエスト追加
                    break;
                // 背景設定
                case "backImageON":

                    talkWindowView.talkBackGroundView.SetBackGroundImage(talkList[i][1]);
                    break;
                // 背景削除
                case "backImageOFF":

                    talkWindowView.talkBackGroundView.ClearBackGroundImage();
                    break;
                // 文章追加
                case "add":

                    // メッセージ追加
                    talkWindowView.AddTalkStr(talkList[++i]);
                    yield return new WaitForSeconds(0.8f);

                    // 次へのアイコン表示
                    talkWindowView.ShowNextIcon();
                    yield return new WaitForSeconds(0.2f);

                    // クリックされたら次の行へ
                    yield return new WaitUntil(() => Mouse.current.leftButton.wasPressedThisFrame);
                    talkWindowView.HideNextIcon();
                    break;
                // シーン切り替え
                case "scene":

                    SceneManager.LoadScene(talkList[i][1]);
                    break;
                // 会話の終了
                case "end":

                    this.DeleteWindow();
                    yield break;
                // 会話表示
                default:

                    // メッセージ表示
                    talkWindowView.SetTalkStr(talkList[i]);
                    yield return new WaitForSeconds(0.8f);

                    // 次へのアイコン表示
                    talkWindowView.ShowNextIcon();
                    yield return new WaitForSeconds(0.2f);

                    // クリックされたら次の行へ
                    yield return new WaitUntil(() => Mouse.current.leftButton.wasPressedThisFrame);
                    talkWindowView.HideNextIcon();
                    break;
            }
        }
    }
}