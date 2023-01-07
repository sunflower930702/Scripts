using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkNPCData {

    private int npcId;
    private string talkFile;
    List<NPCHaveItemData> haveItemList;
    private string shopTalkFile;

    public int NpcId {
        set {this.npcId = value;}
        get {return this.npcId;}
    }
    public string TalkFile {
        set {this.talkFile = value;}
        get {return this.talkFile;}
    }
    public List<NPCHaveItemData> HaveItemList {
        set {this.haveItemList = value;}
        get {return this.haveItemList;}
    }
    public string ShopTalkFile {
        set {this.shopTalkFile = value;}
        get {return this.shopTalkFile;}
    }

}

public class NPCHaveItemData {

    private int listNo;
    private ItemDatabaseTable itemTable;
    private int itemId;

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

}


public class NPCModel : MonoBehaviour
{
    public int npcId;
    public string talkFile;
    public string haveItemFile;
    public string shopTalkFile;

    private List<NPCHaveItemData> haveItemList;


    public void setData(NPCData data) {
        this.npcId = data.Id;
        this.talkFile = data.TalkFilePath;
        this.haveItemFile = data.HaveItemFilePath;
        this.shopTalkFile = data.ShopTalkFilePath;
    }

    public TalkNPCData getTalkData() {
        TalkNPCData result = new TalkNPCData();

        result.NpcId = this.npcId;
        result.TalkFile = this.talkFile;
        result.HaveItemList = initHaveItemList(haveItemFile);
        result.ShopTalkFile = this.shopTalkFile;

        return result;
    }

    public List<NPCHaveItemData> initHaveItemList(string filePath) {

        List<NPCHaveItemData> tmpHaveItemList = new List<NPCHaveItemData>();

        CommonModel commonModel = new CommonModel();
        List<string[]> itemList = commonModel.getCsvArray(filePath, false);

        int count = 0;
        foreach (var item in itemList) {

            NPCHaveItemData tmpItemData = new NPCHaveItemData();
            tmpItemData.ListNo = count;
            tmpItemData.ItemTable = (ItemDatabaseTable)(int.Parse(item[0]));
            tmpItemData.ItemId = int.Parse(item[1]);

            tmpHaveItemList.Insert(count, tmpItemData);

            count++;
        }

        return tmpHaveItemList;
    }
}