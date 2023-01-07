using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using TMPro;

public class ShopNPCHaveItemData {

    private int listNo;
    private ItemDatabaseTable itemTable;
    private int itemId;
    private string itemName;
    private string itemIconPath;
    private int buy;

    public int ListNo {
        set {this.listNo = value;}
        get {return this.listNo;}
    }
    public ItemDatabaseTable ItemTable {
        set {this.itemTable = value;}
        get {return this.itemTable;}
    }
    public int ItemId {
        set {this.itemId = value;}
        get {return this.itemId;}
    }
    public string ItemName {
        set {this.itemName = value;}
        get {return this.itemName;}
    }
    public string ItemIconPath {
        set {this.itemIconPath = value;}
        get {return this.itemIconPath;}
    }
    public int Buy {
        set {this.buy = value;}
        get {return this.buy;}
    }
}

public class ShopPlayerHaveItemData {

    private int listNo;
    private ItemDatabaseTable itemTable;
    private int itemId;
    private int itemCount;
    private string itemName;
    private string itemIconPath;
    private int cell;

    public int ListNo {
        set {this.listNo = value;}
        get {return this.listNo;}
    }
    public ItemDatabaseTable ItemTable {
        set {this.itemTable = value;}
        get {return this.itemTable;}
    }
    public int ItemId {
        set {this.itemId = value;}
        get {return this.itemId;}
    }
    public int ItemCount {
        set {this.itemCount = value;}
        get {return this.itemCount;}
    }
    public string ItemName {
        set {this.itemName = value;}
        get {return this.itemName;}
    }
    public string ItemIconPath {
        set {this.itemIconPath = value;}
        get {return this.itemIconPath;}
    }
    public int Cell {
        set {this.cell = value;}
        get {return this.cell;}
    }
}

public enum ShopMode {
    Buy,
    Cell
}

public enum ShopTalkColumn {
    DefaultBuy,     // 0
    QuestionBuy,    // 1
    ConfirmBuy,     // 2
    DefaultCell,    // 3
    QuestionCell,   // 4
    ConfirmCell     // 5
}

public class ShopModel : MonoBehaviour
{

    public List<ShopNPCHaveItemData> curShopBuyItemList;
    public List<ShopPlayerHaveItemData> curShopCellItemList;

    public TextMeshProUGUI haveGoldText;

    private TalkModel talkModel;
    private PlayerModel playerModel;
    public InfiniteScroll infiniteScroll;

    private string defaultBuyTalkStr;
    private string questionBuyTalkStr;
    private string confirmBuyTalkStr;
    private string defaultCellTalkStr;
    private string questionCellTalkStr;
    private string confirmCellTalkStr;


    void Start() {
        playerModel = GameObject.Find(CommonDefine.PLAYER_NAME).GetComponent<PlayerModel>();
    }

    void Update() {
        haveGoldText.text = playerModel.getGold() + " Gold";
    }

    
    public void init(List<NPCHaveItemData> npCList, List<PlayerHaveItemData> playerList) {

        ItemDatabase itemDatabase = GameObject.Find(CommonDefine.DATABASE_CONTROLLER_NAME).GetComponent<ItemDatabase>(); 

        curShopBuyItemList = new List<ShopNPCHaveItemData>();

        int loopCount = npCList.Count;
        for (int i = 0; i < loopCount; i++) {

            ShopNPCHaveItemData tmpData = new ShopNPCHaveItemData();

            ItemData itemData = itemDatabase.getItemtData(npCList[i].ItemTable, npCList[i].ItemId);

            tmpData.ListNo = npCList[i].ListNo;
            tmpData.ItemTable = npCList[i].ItemTable;
            tmpData.ItemId = npCList[i].ItemId;
            tmpData.ItemName = itemData.ItemName;
            tmpData.ItemIconPath = itemData.ItemIconPath;
            tmpData.Buy = itemData.Buy;

            curShopBuyItemList.Add(tmpData);
        }

        curShopCellItemList = new List<ShopPlayerHaveItemData>();

        loopCount = playerList.Count;
        for (int j = 0; j < loopCount; j++) {

            if (playerList[j].IsEmpty == false) {
                ShopPlayerHaveItemData tmpData = new ShopPlayerHaveItemData();

                ItemData itemData = itemDatabase.getItemtData(playerList[j].ItemTable, playerList[j].ItemId);

                tmpData.ListNo = playerList[j].ListNo;
                tmpData.ItemTable = playerList[j].ItemTable;
                tmpData.ItemId = playerList[j].ItemId;
                tmpData.ItemCount = playerList[j].ItemCount;
                tmpData.ItemName = itemData.ItemName;
                tmpData.ItemIconPath = itemData.ItemIconPath;
                tmpData.Cell = itemData.Cell;

                curShopCellItemList.Add(tmpData);
            }
        }
    }

    public void setShopTalk(string filePath) {

        CommonModel commonModel = new CommonModel();
        List<string[]> shopTalk = commonModel.getCsvArray(filePath, false);

        defaultBuyTalkStr = (shopTalk[(int)ShopTalkColumn.DefaultBuy])[0];
        questionBuyTalkStr = (shopTalk[(int)ShopTalkColumn.QuestionBuy])[0];
        confirmBuyTalkStr = (shopTalk[(int)ShopTalkColumn.ConfirmBuy])[0];
        defaultCellTalkStr = (shopTalk[(int)ShopTalkColumn.DefaultCell])[0];
        questionCellTalkStr = (shopTalk[(int)ShopTalkColumn.QuestionCell])[0];
        confirmCellTalkStr = (shopTalk[(int)ShopTalkColumn.ConfirmCell])[0];

        talkModel.setTalk(defaultBuyTalkStr);
    }

    public void setTalkModel (TalkModel model) {
        talkModel = model;
    }

    public ShopMode getShopMode() {
        return talkModel.curShopMode;
    }

    public void onClickExitButton() {
        talkModel.EndShop();
    }
    public void onClickBuyModeButton() {
        talkModel.resetShop(ShopMode.Buy);

        talkModel.setTalk(defaultBuyTalkStr);
    }
    public void onClickCellModeButton() {
        talkModel.resetShop(ShopMode.Cell);

        talkModel.setTalk(defaultCellTalkStr);
    }

    public void setConfirmMenu(ShopNPCHaveItemData itemData) {
        talkModel.setConfirmMenu(itemData);

        talkModel.setTalk(questionBuyTalkStr);
    }
    public void setConfirmMenu(ShopPlayerHaveItemData itemData) {
        talkModel.setConfirmMenu(itemData);

        talkModel.setTalk(questionCellTalkStr);
    }

    public void buyConfirm(ShopNPCHaveItemData itemData, int count) {
        talkModel.buyConfirm(itemData, count);

        talkModel.setTalk(confirmBuyTalkStr);
    }
    public void cellConfirm(ShopPlayerHaveItemData itemData, int count) {
        talkModel.cellConfirm(itemData, count);

        talkModel.setTalk(confirmCellTalkStr);
    }
}
