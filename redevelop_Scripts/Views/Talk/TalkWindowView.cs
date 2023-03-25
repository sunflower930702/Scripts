using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

/// <summary>
///     会話ウィンドウを扱うビュー
/// </summary>
public class TalkWindowView : MonoBehaviour
{

    /// ==================================================
    /// Member
    /// ==================================================

    // 別オブジェクトへの参照
    // Views
    public TalkAnswerWindowView talkAnswerWindowView;
    public TalkCharacterView talkCharacterView;
    public TalkBackGroundView talkBackGroundView;

    private TextMeshProUGUI textbox;
    public  TextMeshProUGUI textboxLarge;
    public  TextMeshProUGUI textboxSmall;

    private Image nextIcon;
    public  Image nextIconLarge;
    public  Image nextIconSmall;

    private Image talkMenuPanel;
    public  Image talkMenuPanelLarge;
    public  Image talkMenuPanelSmall;


    /// ==================================================
    /// Trigger method
    /// ==================================================

    /// <summary>
    ///     インスタンス生成時に実行
    /// </summary>
    void Start() {
        this.SetTalkStr("");
        this.ChangeSizeLarge();
    }


    /// ==================================================
    /// Public method
    /// ==================================================

    /// <summary>
    ///     会話ウィンドウに1行表示
    /// </summary>
    public void SetTalkStr(string str) {
        this.textbox.text = str;
    }


    /// <summary>
    ///     会話ウィンドウに複数行表示
    /// </summary>
    public void SetTalkStr(string[] strList) {

        string str = "";
        foreach (string s in strList) {
            str = str + s + "\n";
        }
        this.SetTalkStr(str);
    }

    /// <summary>
    ///     会話ウィンドウに文字列を追加
    /// </summary>
    public void AddTalkStr(string str) {
        this.textbox.text = this.textbox.text + "\n" + str;
    }

    /// <summary>
    ///     会話ウィンドウに文字列を追加
    /// </summary>
    public void AddTalkStr(string[] strList) {

        string str = "";
        foreach (string s in strList) {
            str = str + s + "\n";
        }
        this.AddTalkStr(str);
    }

    /// <summary>
    ///     次へアイコン表示
    /// </summary>
    public void ShowNextIcon() {
        this.nextIcon.color = new Color32(255, 255, 255, 255);
    }

    /// <summary>
    ///     次へアイコン非表示
    /// </summary>
    public void HideNextIcon() {
        this.nextIcon.color = new Color32(255, 255, 255, 0);
    }

    /// <summary>
    ///     会話ウィンドウを大きいサイズに変更
    /// </summary>
    public void ChangeSizeLarge() {

        this.textboxLarge.enabled = true;
        this.nextIconLarge.enabled = true;
        this.talkMenuPanelLarge.enabled = true;

        this.textbox = this.textboxLarge;
        this.nextIcon = this.nextIconLarge;
        this.talkMenuPanel = this.talkMenuPanelLarge;

        this.textboxSmall = false;
        this.nextIconSmall = false;
        this.talkMenuPanelSmall = false;
    }

    /// <summary>
    ///     会話ウィンドウを小さいサイズに変更
    /// </summary>
    public void ChangeSizeSmall() {

        this.textboxSmall = true;
        this.nextIconSmall = true;
        this.talkMenuPanelSmall = true;
        
        this.textbox = this.textboxSmall;
        this.nextIcon = this.nextIconSmall;
        this.talkMenuPanel = this.talkMenuPanelSmall;

        this.textboxLarge.enabled = false;
        this.nextIconLarge.enabled = false;
        this.talkMenuPanelLarge.enabled = false;
    }
}