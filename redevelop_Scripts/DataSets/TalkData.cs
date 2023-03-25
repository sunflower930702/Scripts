/// <summary>
///     NPCの会話の情報をまとめたクラス
/// </summary>
public class NpcTalkData
{

    /// ==================================================
    /// Properties
    /// ==================================================

    /// <summary>
    ///     テーブル上のNPCのID
    /// </summary>
    public int NpcId { get; set; }

    /// <summary>
    ///     会話内容のCSVファイルパス
    /// </summary>
    public string TalkFile { get; set; }

    /// <summary>
    ///     所持アイテム
    /// </summary>
    public List<NPCHaveItemData> HaveItemList { get; set; }

    /// <summary>
    ///     お店での会話内容のCSVファイルパス
    /// </summary>
    public string ShopTalkFile { get; set; }
}
