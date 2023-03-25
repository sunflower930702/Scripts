/// <sumarry>
///     NPCの情報を内包するクラス
/// </summary>
public class NpcRecordData : RecordData
{

    /// ==================================================
    /// Properties
    /// ==================================================

    /// <summary>
    ///     テーブル上でのID
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    ///     
    /// </summary>
    public bool UseLayer { get; set; }

    /// <summary>
    ///     名前
    /// </summary>
    public string NPCName { get; set; }

    /// <summary>
    ///     立ち絵のファイルパス
    /// </summary>
    public string NPCIllustPath { get; set; }

    /// <summary>
    ///     アイコンのファイルパス
    /// </summary>
    public string NPCIconPath { get; set; }

    /// <summary>
    ///     会話内容のCSVファイルパス
    /// </summary>
    public string TalkFilePath { get; set; }

    /// <summary>
    ///     所持アイテムのCSVファイルパス
    /// </summary>
    public string HaveItemFilePath { get; set; }

    /// <summary>
    ///     お店での会話内容のCSVファイルパス
    /// </summary>
    public string ShopTalkFilePath { get; set; }


    /// ==================================================
    /// Public Method
    /// ==================================================

    /// <summary>
    ///     コンストラクタ
    /// </summary>
    public void NpcRecordData() {

        this.Id = null;
        this.UseLayer = null;
        this.NPCName = null;
        this.NPCIllustPath = null;
        this.NPCIconPath = null;
        this.TalkFilePath = null;
        this.HaveItemFilePath = null;
        this.ShopTalkFilePath = null;
    }
}