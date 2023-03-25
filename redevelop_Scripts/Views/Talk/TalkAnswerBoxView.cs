using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

/// <summary>
///     会話ウィンドウを扱うビュー
/// </summay>
public class TalkAnswerBoxView : MonoBehaviour
{

    /// ==================================================
    /// Members
    /// ==================================================

    // 別オブジェクトへの参照
    // Views
    public TalkAnswerWindowView talkAnswerWindowView;

    // Prefab内GameObject
    public TextMeshProUGUI answerText;

    /// <summary>
    ///     固有の解答No
    /// </summary>
    private int answerNo;


    /// ==================================================
    /// Trigger Method
    /// ==================================================

    /// <summary>
    ///     プレイヤーが解答選択時に実行
    /// </summary>
    public void OnAnswer() {
        talkAnswerWindowView.SetAnswer(this.answerNo);
    }


    /// ==================================================
    /// Public method
    /// ==================================================

    /// <summary>
    ///     解答データをセット
    /// </summary>
    public void SetAnswerData(AnswerData data) {

        this.answerNo = data.AnswerNo;
        answerText.text = data.AnswerText;
    }
}