using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public enum TalkMenuSize {
    Large,
    Small
}


public class TalkModel : MonoBehaviour
{

    public GameObject answerPrefab;

    private PlayerModel playerModel;

    private TalkMenuSize curTalkMenuSize;
    private Image curTalkMenuPanel;
    private TextMeshProUGUI curText;
    private Image curNextIcon;

    public Image largeTalkMenuPanel;
    public TextMeshProUGUI largeText;
    public Image largeNextIcon;

    public Image smallTalkMenuPanel;
    public TextMeshProUGUI smallText;
    public Image smallNextIcon;

    public TextMeshProUGUI npcName;
    public Image backGroundImage;
    public Image characterImage;

    public Image backPanel;


    private List<GameObject> answerList;
    private bool isAnswered;
    private AnswerData responseAnswerData;

    public GameObject shopListPrefab;
    public ShopMode curShopMode;
    private List<NPCHaveItemData> npcHaveItemList;
    private string shopTalkFile;
    private ShopModel shopModel;
    private bool isFinishShop;
    public GameObject confirmPrefab;
    private GameObject confirmMenu;


    public void init(bool isRefPlayer) {

        setTalk("");
        setCharacter(0);
        closeNextIcon();
        setBackGroundImage(CommonDefine.NULL_IMAGE_PATH);

        if (isRefPlayer) {
            playerModel = GameObject.Find(CommonDefine.PLAYER_NAME).GetComponent<PlayerModel>();
        }

        isAnswered = false;
        isFinishShop = false;
    }

    public void setTalk(string str) {
        curText.text = str;
    }
    public void addTalk(string str) {
        curText.text = curText.text + "\n" + str;
    }

    public void setAnswer(List<AnswerData> list) {

        int i = 0;
        float height = 85.0f;

        answerList = new List<GameObject>();

        foreach (AnswerData data in list) {

            GameObject tmpAnswer = Instantiate(answerPrefab);
            tmpAnswer.transform.SetParent(this.gameObject.transform, false);
            tmpAnswer.transform.Translate(0, height * i, 0);

            answerList.Add(tmpAnswer);

            AnswerModel tmpModel = tmpAnswer.GetComponent<AnswerModel>();
            tmpModel.initData(data);
            tmpModel.setTalkModel(this);

            i++;
        }
    }

    public void closeAnswer() {

        foreach (GameObject answerObj in answerList) {
            Destroy(answerObj);
        }

        answerList = new List<GameObject>();

        isAnswered = false;
    }

    public void setCharacter(int npcId) {

        NPCData joinNpcData = GameObject.Find(CommonDefine.DATABASE_CONTROLLER_NAME).GetComponent<NPCDatabase>().getNPCData(npcId);
        characterImage.sprite = Resources.Load<Sprite>(joinNpcData.NPCIllustPath);
    }

    public void setBackGroundImage(string imagePath) {
        backGroundImage.sprite = Resources.Load<Sprite>(imagePath);
    }

    public void setBackPanel() {
        backPanel.enabled = true;
    }
    public void deleteBackPanel() {
        backPanel.enabled = false;
    }

    public void changeTalkSize(TalkMenuSize size) {
        curTalkMenuSize = size;

        switch (size) {
            case TalkMenuSize.Large:
                largeTalkMenuPanel.enabled = true;
                largeText.enabled = true;
                largeNextIcon.enabled = true;

                curTalkMenuPanel = largeTalkMenuPanel;
                curText = largeText;
                curNextIcon = largeNextIcon;

                smallTalkMenuPanel.enabled = false;
                smallText.enabled = false;
                smallNextIcon.enabled = false;
                break;
            case TalkMenuSize.Small:
                smallTalkMenuPanel.enabled = true;
                smallText.enabled = true;
                smallNextIcon.enabled = true;

                curTalkMenuPanel = smallTalkMenuPanel;
                curText = smallText;
                curNextIcon = smallNextIcon;

                largeTalkMenuPanel.enabled = false;
                largeText.enabled = false;
                largeNextIcon.enabled = false;
                break;
        }
    }

    public void setNextIcon() {
        curNextIcon.color = new Color32(255, 255, 255, 255);
    }
    public void closeNextIcon() {
        curNextIcon.color = new Color32(255, 255, 255, 0);
    }

    public void setNPCHaveItemList(List<NPCHaveItemData> list) {
        npcHaveItemList = list;
    }
    public void setShopTalkFile(string path) {
        shopTalkFile = path;
    }

    public void setShop() {
        if (playerModel != null) {
            GameObject shopListObj = Instantiate(shopListPrefab, shopListPrefab.transform.position, Quaternion.identity);
            shopListObj.transform.SetParent(this.gameObject.transform, false);

            shopModel = shopListObj.GetComponent<ShopModel>();
            shopModel.init(npcHaveItemList, playerModel.getHaveItemList());
            shopModel.setTalkModel(this);

            changeTalkSize(TalkMenuSize.Small);
            setTalk("");
            closeNextIcon();
            isFinishShop = false;

            shopModel.setShopTalk(shopTalkFile);
        }
    }

    public void closeShop() {
        Destroy(shopModel.gameObject);
        if (confirmMenu != null) {
            Destroy(confirmMenu);
            confirmMenu = null;
        }

        changeTalkSize(TalkMenuSize.Large);
        setTalk("");
        isFinishShop = false;
    }

    public void resetShop(ShopMode mode) {
        curShopMode = mode;
        closeShop();
        setShop();
    }

    public void setConfirmMenu(ShopNPCHaveItemData itemData) {
        if (confirmMenu == null) {
            GameObject tmpConfirmMenu = Instantiate(confirmPrefab, confirmPrefab.transform.position, Quaternion.identity);
            tmpConfirmMenu.transform.SetParent(this.transform, false);

            confirmMenu = tmpConfirmMenu;
        }

        ConfirmModel model = confirmMenu.GetComponent<ConfirmModel>();
        model.init();
        model.setShopModel(shopModel);

        int maxVal = 0;
        if (playerModel != null) {
            maxVal = playerModel.getMaxGetableValue(itemData.ItemTable, itemData.ItemId);
        }
        model.setMax(maxVal);
        model.setShopItemData(itemData);
        model.setMessage(itemData.ItemName + "を選択中");
    }

    public void setConfirmMenu(ShopPlayerHaveItemData itemData) {
        if (confirmMenu == null) {
            GameObject tmpConfirmMenu = Instantiate(confirmPrefab, confirmPrefab.transform.position, Quaternion.identity);
            tmpConfirmMenu.transform.SetParent(this.transform, false);

            confirmMenu = tmpConfirmMenu;
        }

        ConfirmModel model = confirmMenu.GetComponent<ConfirmModel>();
        model.init();
        model.setShopModel(shopModel);

        int maxVal = itemData.ItemCount;
        model.setMax(maxVal);
        model.setShopItemData(itemData);
        model.setMessage(itemData.ItemName + "を選択中");
    }

    public void buyConfirm(ShopNPCHaveItemData itemData, int count) {
        Destroy(confirmMenu);
        confirmMenu = null;

        if (playerModel != null) {
            playerModel.buyItem(itemData.ItemTable, itemData.ItemId, count);
        }
    }
    public void cellConfirm(ShopPlayerHaveItemData itemData, int count) {
        Destroy(confirmMenu);
        confirmMenu = null;

        if (playerModel != null) {
            playerModel.cellItem(itemData.ListNo, itemData.ItemTable, itemData.ItemId, count);
        }

        resetShop(ShopMode.Cell);
    }

    public void answer(AnswerData data) {
        responseAnswerData = data;
        isAnswered = true;
    }
    public bool checkAnswer() {
        return isAnswered;
    }
    public AnswerData getAnswer() {
        return responseAnswerData;
    }

    public void EndShop() {
        isFinishShop = true;
    }
    public bool checkFinishShop() {
        return isFinishShop;
    }
}
