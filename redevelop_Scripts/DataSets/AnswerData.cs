/// <summary>
///     会話ウィンドウの選択肢の解答情報をまとめたクラス
/// </summary>
public class AnswerData
{

    /// ==================================================
    /// Properties
    /// ==================================================

    /// <summary>
    ///     選択肢No
    /// </summary>
    public int AnswerNo { get; set; }

    /// <summary>
    ///     解答文
    /// </summary>
    public string AnswerText { get; set; }

    /// <summary>
    ///     遷移先
    /// </summary>
    public int JumpNo { get; set; }
}