using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum NPCDatabaseColumn {
    Id = 0,           // 0
    UseLayer,         // 1
    NPCName,          // 2
    NPCIllustPath,    // 3
    NPCIconPath,      // 4
    TalkFilePath,     // 5
    HaveItemFilePath, // 6
    ShopTalkFilePath  // 7
}

public class NPCData {

    // クラス変数
    private int id;
    private bool useLayer;
    private string npcName;
    private string npcIllustPath;
    private string npcIconPath;
    private string talkFilePath;
    private string haveItemFilePath;
    private string shopTalkFilePath;

    // プロパティ
    public int Id {
        set {this.id = value;}
        get {return this.id;}
    }
    public bool UseLayer {
        set {this.useLayer = value;}
        get {return this.useLayer;}
    }
    public string NPCName {
        set {this.npcName = value;}
        get {return this.npcName;}
    }
    public string NPCIllustPath {
        set {this.npcIllustPath = value;}
        get {return this.npcIllustPath;}
    }
    public string NPCIconPath {
        set {this.npcIconPath = value;}
        get {return this.npcIconPath;}
    }
    public string TalkFilePath {
        set {this.talkFilePath = value;}
        get {return this.talkFilePath;}
    }
    public string HaveItemFilePath {
        set {this.haveItemFilePath = value;}
        get {return this.haveItemFilePath;}
    }
    public string ShopTalkFilePath {
        set {this.shopTalkFilePath = value;}
        get {return this.shopTalkFilePath;}
    }

    public void setData(ArrayList arrayList) {

        Id = int.Parse((string)arrayList[(int)NPCDatabaseColumn.Id]);
        UseLayer = int.Parse((string)arrayList[(int)NPCDatabaseColumn.UseLayer]) == 1 ? true : false;
        NPCName = (string)arrayList[(int)NPCDatabaseColumn.NPCName];
        NPCIllustPath = (string)arrayList[(int)NPCDatabaseColumn.NPCIllustPath];
        NPCIconPath = (string)arrayList[(int)NPCDatabaseColumn.NPCIconPath];
        TalkFilePath = (string)arrayList[(int)NPCDatabaseColumn.TalkFilePath];
        HaveItemFilePath = (string)arrayList[(int)NPCDatabaseColumn.HaveItemFilePath];
        ShopTalkFilePath = (string)arrayList[(int)NPCDatabaseColumn.ShopTalkFilePath];
    }
}