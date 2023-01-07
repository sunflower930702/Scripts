using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemDatabaseTable {
    Plant = 0,      // 0
    Equip           // 1
}

public enum ItemDatabaseColumn {
    Id = 0,         // 0
    ItemName,       // 1
    ItemContent,    // 2
    ItemType,       // 3
    ItemIconPath,   // 4
    ItemImagePath,  // 5
    ItemReality,    // 6
    HaveMax,        // 7
    Cell,           // 8
    Buy             // 9
}

public enum ItemType {
    Use = 0,        // 0
    UseDelete,      // 1
    Equip,          // 2
    None            // 3
}

public enum ItemReality {
    None = 0,       // 0
    N,              // 1
    R,              // 2
    SR,             // 3
    SSR,            // 4
    UR,             // 5
    B               // 6
}

public class ItemData {

    // クラス変数
    private int id;
    private string itemName;
    private string itemContent;
    private ItemType itemType;
    private string itemIconPath;
    private string itemImagePath;
    private ItemReality itemReality;
    private int haveMax;
    private int cell;
    private int buy;

    // プロパティ
    public int Id {
        set {this.id = value;}
        get {return this.id;}
    }
    public string ItemName {
        set {this.itemName = value;}
        get {return this.itemName;}
    }
    public string ItemContent {
        set {this.itemContent = value;}
        get {return this.itemContent;}
    }
    public ItemType ItemType {
        set {this.itemType = value;}
        get {return this.itemType;}
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
    public int HaveMax {
        set {this.haveMax = value;}
        get {return this.haveMax;}
    }
    public int Cell {
        set {this.cell = value;}
        get {return this.cell;}
    }
    public int Buy {
        set {this.buy = value;}
        get {return this.buy;}
    }

    public void setData(ArrayList arrayList) {

        Id = int.Parse((string)arrayList[(int)ItemDatabaseColumn.Id]);
        ItemName = (string)arrayList[(int)ItemDatabaseColumn.ItemName];
        ItemContent = (string)arrayList[(int)ItemDatabaseColumn.ItemContent];
        ItemType = (ItemType)(int.Parse((string)arrayList[(int)ItemDatabaseColumn.ItemType]));
        ItemIconPath = (string)arrayList[(int)ItemDatabaseColumn.ItemIconPath];
        ItemImagePath = (string)arrayList[(int)ItemDatabaseColumn.ItemImagePath];
        ItemReality = (ItemReality)(int.Parse((string)arrayList[(int)ItemDatabaseColumn.ItemReality]));
        HaveMax = int.Parse((string)arrayList[(int)ItemDatabaseColumn.HaveMax]);
        Cell = int.Parse((string)arrayList[(int)ItemDatabaseColumn.Cell]);
        Buy = int.Parse((string)arrayList[(int)ItemDatabaseColumn.Buy]);
    }
}