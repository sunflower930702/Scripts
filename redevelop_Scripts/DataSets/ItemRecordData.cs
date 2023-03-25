/// <sumarry>
///    アイテムの情報を内包するクラス
/// </summary>
public class ItemRecordData : RecordData
{

    /// ==================================================
    /// Properties
    /// ==================================================

    /// <summary>
    ///     テーブル上でのID
    /// <summary>
    public int Id { get; set; }

    /// <summary>
    ///     名前
    /// <summary>
    public string ItemName { get; set; }

    /// <summary>
    ///     説明
    /// <summary>
    public string ItemContent { get; set; }

    /// <summary>
    ///     種別
    /// <summary>
    public ItemTypes ItemType { get; set; }

    /// <summary>
    ///     アイコンのファイルパス
    /// <summary>
    public string ItemIconPath { get; set; }

    /// <summary>
    ///     画像のファイルパス
    /// <summary>
    public string ItemImagePath { get; set; }

    /// <summary>
    ///     レアリティ
    /// <summary>
    public ItemRealitys ItemReality { get; set; }

    /// <summary>
    ///     1所持枠の最大数
    /// <summary>
    public int HaveMax { get; set; }

    /// <summary>
    ///     売値
    /// <summary>
    public int Cell { get; set; }

    /// <summary>
    ///     買値
    /// <summary>
    public int Buy { get; set; }


    /// ==================================================
    /// Public Method
    /// ==================================================

    /// <summary>
    ///     コンストラクタ
    /// </summary>
    public void ItemRecordData() {

        this.Id = null;
        this.ItemName = null;
        this.ItemContent = null;
        this.ItemType = null;
        this.ItemIconPath = null;
        this.ItemImagePath = null;
        this.ItemReality = null;
        this.HaveMax = null;
        this.Cell = null;
        this.Buy = null;
    }
}