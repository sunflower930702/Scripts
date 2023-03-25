using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

/// <summary>
///     会話背景を扱うビュー
/// </summay>
public class TalkBackGroundView : MonoBehaviour
{

    /// ==================================================
    /// Members
    /// ==================================================

    // Prefab内GameObject
    public Image backGroundImage;


    /// ==================================================
    /// Trigger method
    /// ==================================================

    /// <summary>
    ///     インスタンス生成時に実行
    /// </summary>
    void Start() {
        this.ClearNpcIllust();
    }


    /// ==================================================
    /// Public method
    /// ==================================================

    /// <summary>
    ///     背景を変更する
    /// </summary>
    public void SetBackGroundImage(string imagePath) {
        this.backGroundImage.sprite = Resources.Load<Sprite>(imagePath);
    }

    /// <summary>
    ///     背景を削除する
    /// </summary>
    public void ClearBackGroundImage() {
        this.backGroundImage.sprite = Resources.Load<Sprite>(CommonDefine.NULL_IMAGE_PATH);
    }
}