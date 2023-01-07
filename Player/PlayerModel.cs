using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHaveItemData {

    private int listNo;
    private ItemDatabaseTable itemTable;
    private int itemId;
    private int itemCount;
    private bool isEmpty;

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
    public bool IsEmpty {
        set {this.isEmpty = value;}
        get {return this.isEmpty;}
    }


    public void setEmptyItemData() {
        this.itemTable = (ItemDatabaseTable)0;
        this.itemId = -1;
        this.itemCount = 0;
        this.isEmpty = true;
    }
}

public class InventoryHaveItemData {

    private int listNo;
    private ItemDatabaseTable itemTable;
    private int itemId;
    private string itemCount;
    private string itemName;
    private string itemIconPath;
    private string itemImagePath;
    private ItemReality itemReality;
    private string itemContent;
    private ItemType itemType;
    private bool isEmpty;

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
    public string ItemCount {
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
    public string ItemImagePath {
        set {this.itemImagePath = value;}
        get {return this.itemImagePath;}
    }
    public ItemReality ItemReality {
        set {this.itemReality = value;}
        get {return this.itemReality;}
    }
    public string ItemContent {
        set {this.itemContent = value;}
        get {return this.itemContent;}
    }
    public ItemType ItemType {
        set {this.itemType = value;}
        get {return this.itemType;}
    }
    public bool IsEmpty {
        set {this.isEmpty = value;}
        get {return this.isEmpty;}
    }

    public void setEmptyItemData() {
        this.itemTable = 0;
        this.itemId = 0;
        this.itemCount = "";
        this.itemName = "";
        this.itemIconPath = CommonDefine.NULL_IMAGE_PATH;
        this.itemImagePath = CommonDefine.NULL_IMAGE_PATH;
        this.itemReality = ItemReality.None;
        this.itemContent = "";
        this.itemType = ItemType.None;
        this.isEmpty = true;
    }
}

public class EquipItemData {

    private ItemDatabaseTable itemTable;
    private int itemId;
    private bool isEmpty;

    public ItemDatabaseTable ItemTable {
        set {this.itemTable = value;}
        get {return this.itemTable;}
    }
    public int ItemId {
        set {this.itemId = value;}
        get {return this.itemId;}
    }
    public bool IsEmpty {
        set {this.isEmpty = value;}
        get {return this.isEmpty;}
    }

    public void setEmptyItemData() {
        ItemTable = 0;
        ItemId = 0;
        IsEmpty = true;
    }
}

public class EquipMenuHaveItemData {

    private int listNo;
    private ItemDatabaseTable itemTable;
    private int itemId;
    private string itemName;
    private string itemIconPath;
    private bool isEmpty;

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
    public bool IsEmpty {
        set {this.isEmpty = value;}
        get {return this.isEmpty;}
    }

    public void setEmptyItemData() {
        itemTable = 0;
        itemId = 0;
        itemName = "";
        itemIconPath = CommonDefine.NULL_IMAGE_PATH;
        isEmpty = true;
    }
}

public class PartyData {

    private int partyNPCId;
    private string iconImage;
    private string standImage;
    private List<EquipMenuHaveItemData> equipData;

    public string StandImage {
        set {this.standImage = value;}
        get {return this.standImage;}
    }
    public string IconImage {
        set {this.iconImage = value;}
        get {return this.iconImage;}
    }
    public int PartyNPCId {
        set {this.partyNPCId = value;}
        get {return this.partyNPCId;}
    }
    public List<EquipMenuHaveItemData> EquipData {
        set {this.equipData = value;}
        get {return this.equipData;}
    }
}


public class PlayerModel : MonoBehaviour
{

    private List<PlayerHaveItemData> haveItemList;
    private List<EquipItemData> equipItemList;
    private int haveGold = 999999999;

    // TODO 取得方法
    public string charaIconImagePath;
    public string charaImagePath; 


    // パーティー情報
    public List<PartyNPCModel> partyNPCModels;

    public ItemDatabase itemDatabase;


    void Start() {
        initHaveItemList();
        initEquipItemList();

        // TODO テスト用にアイテム追加処理 追加
        addItem(ItemDatabaseTable.Equip, 0, 1);
        addItem(ItemDatabaseTable.Equip, 1, 1);
        addItem(ItemDatabaseTable.Equip, 2, 1);
        addItem(ItemDatabaseTable.Equip, 3, 1);
    }


    public int addItem(ItemDatabaseTable table, int id, int count) {

        ItemData itemData = itemDatabase.getItemtData(table, id);

        int i = count;

        while (i > 0) {
            foreach (PlayerHaveItemData haveItem in haveItemList) {
                if (haveItem.IsEmpty == false && haveItem.ItemTable == table && haveItem.ItemId == id) {
                    if (haveItem.ItemCount < itemData.HaveMax) {
                        haveItem.ItemCount++;
                        count--;
                        break;
                    }
                }
            }

            i--;
        }

        if (count > 0) {
            foreach (PlayerHaveItemData haveItem in haveItemList) {
                if (haveItem.IsEmpty) {
                    if (count <= itemData.HaveMax) {
                        haveItem.ItemTable = table;
                        haveItem.ItemId = id;
                        haveItem.ItemCount = count;
                        haveItem.IsEmpty = false;

                        count = 0;
                        break;
                    } else {
                        haveItem.ItemTable = table;
                        haveItem.ItemId = id;
                        haveItem.ItemCount = itemData.HaveMax;
                        haveItem.IsEmpty = false;

                        count -= itemData.HaveMax;
                    }
                }
            }
        }

        return count;
    }

    public void deleteItem(int listNo, int count) {

        haveItemList[listNo].ItemCount -= count;

        if (haveItemList[listNo].ItemCount <= 0) {
            haveItemList[listNo].setEmptyItemData();
        }
    }
    public void deleteItem(ItemDatabaseTable table, int id, int count) {

        List<PlayerHaveItemData> tmpList = new List<PlayerHaveItemData>();

        int i = count;

        while (i > 0) {
            foreach (PlayerHaveItemData haveItem in haveItemList) {
                if (haveItem.IsEmpty == false && haveItem.ItemTable == table && haveItem.ItemId == id) {

                    haveItem.ItemCount--;

                    if (haveItem.ItemCount <= 0) {
                        haveItem.setEmptyItemData();
                    }
                }
                tmpList.Add(haveItem);
            }

            i--;
        }

        haveItemList = tmpList;
    }

    public void moveItem(PlayerHaveItemData from, PlayerHaveItemData to) {

        if (from.ItemTable == to.ItemTable && from.ItemId == to.ItemId && from.IsEmpty == false && to.IsEmpty == false) {

            ItemData itemData = itemDatabase.getItemtData(from.ItemTable, from.ItemId);

            if (from.ItemCount + to.ItemCount <= itemData.HaveMax) {
                haveItemList[to.ListNo].ItemCount = from.ItemCount + to.ItemCount;
                haveItemList[from.ListNo].setEmptyItemData();
            } else {
                haveItemList[to.ListNo].ItemCount = itemData.HaveMax;
                haveItemList[from.ListNo].ItemCount = to.ItemCount - (itemData.HaveMax - from.ItemCount);
            }
        } else {
            swapItem(from, to);
        }
    }

    public bool checkEquipable() {

        int count = 0;

        foreach (EquipItemData equipItemData in equipItemList) {
            if (equipItemData.IsEmpty == false) {
                count++;
            }
        }

        if (count >= CommonDefine.EQUIP_SIZE) {
            return false;
        }

        return true;
    }

    public void equipItem(ItemDatabaseTable table, int id) {

        List<EquipItemData> tmpList = new List<EquipItemData>();

        bool isEquiped = false;
        foreach (EquipItemData equipItemData in equipItemList) {
            if (equipItemData.IsEmpty && isEquiped == false) {

                equipItemData.ItemTable = table;
                equipItemData.ItemId = id;
                equipItemData.IsEmpty = false;

                isEquiped = true;
            }
            tmpList.Add(equipItemData);
        }

        equipItemList = tmpList;

        if (isEquiped) {
            deleteItem(table, id, 1);
        }
    }

    public bool unEquipItem(int listNo) {

        int addCount = addItem(equipItemList[listNo].ItemTable, equipItemList[listNo].ItemId, 1);

        if (addCount == 1) {
            return false;
        }

        equipItemList[listNo].setEmptyItemData();

        List<EquipItemData> tmpList = new List<EquipItemData>();
        foreach (EquipItemData equipItemdata in equipItemList) {
            if (equipItemdata.IsEmpty == false) {
                tmpList.Add(equipItemdata);
            }
        }
        foreach (EquipItemData equipItemdata in equipItemList) {
            if (equipItemdata.IsEmpty == true) {
                tmpList.Add(equipItemdata);
            }
        }

        equipItemList = tmpList;
        return true;
    }

    public bool checkEquipableNpc(int partyNpcId) {

        foreach (PartyNPCModel partyNPCModel in partyNPCModels) {
            if (partyNPCModel.partyNPCId == partyNpcId) {

                return partyNPCModel.checkEquipableNpc();
            }
        }

        return false;
    }

    public void equipItemNpc(ItemDatabaseTable table, int id, int partyNpcId) {

        bool isEquiped = false;
        foreach (PartyNPCModel partyNPCModel in partyNPCModels) {
            if (partyNPCModel.partyNPCId == partyNpcId) {
                partyNPCModel.equipItem(table, id);
                isEquiped = true;
            }
        }

        if (isEquiped) {
            deleteItem(table, id, 1);
        }
    }

    public bool unEquipItemNpc(int listNo, int partyNpcId) {

        foreach (PartyNPCModel partyNPCModel in partyNPCModels) {
            if (partyNPCModel.partyNPCId == partyNpcId) {

                List<EquipMenuHaveItemData> npcEquipItemList =  partyNPCModel.getEquipItemList();
                int addCount = addItem(npcEquipItemList[listNo].ItemTable, npcEquipItemList[listNo].ItemId, 1);

                if (addCount == 1) {
                    return false;
                }

                partyNPCModel.unEquipItem(listNo);

                return true;
            }
        }

        return false;
    }

    public List<PlayerHaveItemData> getHaveItemList() {
        return haveItemList;
    }

    public List<InventoryHaveItemData> getInventoryHaveItemList() {

        List<InventoryHaveItemData> result = new List<InventoryHaveItemData>();

        int max = CommonDefine.INVENTORY_X_SIZE * CommonDefine.INVENTORY_Y_SIZE;
        for (int i = 0; i < max; i++) {
            InventoryHaveItemData tmpItemData = new InventoryHaveItemData();

            if (haveItemList[i].IsEmpty) {
                tmpItemData.setEmptyItemData();
                tmpItemData.ListNo = i;
            } else {
                ItemData dbItemData = itemDatabase.getItemtData(haveItemList[i].ItemTable, haveItemList[i].ItemId);

                tmpItemData.ListNo = i;
                tmpItemData.ItemTable = haveItemList[i].ItemTable;
                tmpItemData.ItemId = haveItemList[i].ItemId;
                tmpItemData.ItemCount = haveItemList[i].ItemCount.ToString();
                tmpItemData.ItemName = dbItemData.ItemName;
                tmpItemData.ItemIconPath = dbItemData.ItemIconPath;
                tmpItemData.ItemImagePath = dbItemData.ItemImagePath;
                tmpItemData.ItemReality = dbItemData.ItemReality;
                tmpItemData.ItemContent = dbItemData.ItemContent;
                tmpItemData.ItemType = dbItemData.ItemType;
                tmpItemData.IsEmpty = false;
            }

            result.Add(tmpItemData);
        }

        return result;
    }

    public void buyItem(ItemDatabaseTable table, int id, int count) {

        ItemData dbItemData = itemDatabase.getItemtData(table, id);

        addItem(table, id, count);
        reduceGold(dbItemData.Buy * count);
    }

    public void cellItem(int listNo, ItemDatabaseTable table, int id, int count) {

        ItemData dbItemData = itemDatabase.getItemtData(table, id);

        deleteItem(listNo, count);
        addGold(dbItemData.Cell * count);
    }

    public void addGold(int gold) {
        haveGold += gold;
    }
    public void reduceGold(int gold) {
        haveGold -= gold;
    }
    public int getGold() {
        return haveGold;
    }

    public int getMaxGetableValue(ItemDatabaseTable table, int id) {

        ItemData dbItemData = itemDatabase.getItemtData(table, id);

        int result = 0;
        int tmpGold = haveGold;

        foreach (PlayerHaveItemData haveItem in haveItemList) {
            if (haveItem.ItemTable == table && haveItem.ItemId == id && haveItem.IsEmpty == false) {

                int tmpCount = dbItemData.HaveMax - haveItem.ItemCount;
                for (int i = 0; i < tmpCount; i++){
                    if (tmpGold - dbItemData.Buy >= 0) {
                        result++;
                        tmpGold -= dbItemData.Buy;
                    } else {
                        break;
                    }
                }
            } else if (haveItem.IsEmpty) {

                for (int j = 0; j < dbItemData.HaveMax; j++){
                    if (tmpGold - dbItemData.Buy >= 0) {
                        result++;
                        tmpGold -= dbItemData.Buy;
                    } else {
                        break;
                    }
                }
            }
        }

        return result;
    }

    public void addQuest(int questId) {

    }


    private void initHaveItemList() {

        haveItemList = new List<PlayerHaveItemData>();

        int listSize = CommonDefine.INVENTORY_X_SIZE * CommonDefine.INVENTORY_Y_SIZE;
        for (int i = 0; i < listSize; i++) {
            PlayerHaveItemData tmpItemData = new PlayerHaveItemData();
            tmpItemData.setEmptyItemData();
            tmpItemData.ListNo = i;

            haveItemList.Add(tmpItemData);
        }
    }

    private void swapItem(PlayerHaveItemData from, PlayerHaveItemData to) {

        haveItemList[to.ListNo].ItemTable = from.ItemTable;
        haveItemList[to.ListNo].ItemId = from.ItemId;
        haveItemList[to.ListNo].ItemCount = from.ItemCount;
        haveItemList[to.ListNo].IsEmpty = from.IsEmpty;

        haveItemList[from.ListNo].ItemTable = to.ItemTable;
        haveItemList[from.ListNo].ItemId = to.ItemId;
        haveItemList[from.ListNo].ItemCount = to.ItemCount;
        haveItemList[from.ListNo].IsEmpty = to.IsEmpty;
    }

    public List<EquipMenuHaveItemData> getEquipItemList() {

        List<EquipMenuHaveItemData> result = new List<EquipMenuHaveItemData>();

        int max = CommonDefine.EQUIP_SIZE;

        for (int i = 0; i < max; i++) {
            EquipMenuHaveItemData tmpItemData = new EquipMenuHaveItemData();

            if (equipItemList[i].IsEmpty) {
                tmpItemData.setEmptyItemData();
                tmpItemData.ListNo = i;
            } else {
                ItemData dbItemData = itemDatabase.getItemtData(equipItemList[i].ItemTable, equipItemList[i].ItemId);

                tmpItemData.ItemTable = equipItemList[i].ItemTable;
                tmpItemData.ItemId = equipItemList[i].ItemId;
                tmpItemData.ItemName = dbItemData.ItemName;
                tmpItemData.ItemIconPath = dbItemData.ItemIconPath;
                tmpItemData.IsEmpty = false;
            }

            result.Add(tmpItemData);
        }

        return result;
    }

    public void initEquipItemList() {

        equipItemList = new List<EquipItemData>();

        int listSize = CommonDefine.EQUIP_SIZE;
        for (int i = 0; i < listSize; i++) {
            EquipItemData tmpItemData = new EquipItemData();
            tmpItemData.setEmptyItemData();

            equipItemList.Add(tmpItemData);
        }
    }

    public List<PartyData> getPartyData() {

        List<PartyData> list = new List<PartyData>();

        PartyData playerData = new PartyData();
        playerData.PartyNPCId = 0;
        playerData.StandImage = charaImagePath;
        playerData.IconImage = charaIconImagePath;
        playerData.EquipData = getEquipItemList();

        list.Add(playerData);

        foreach (PartyNPCModel partyNPCModel in partyNPCModels) {
            list.Add(partyNPCModel.getPartyData());
        }

        return list;
    }
}
