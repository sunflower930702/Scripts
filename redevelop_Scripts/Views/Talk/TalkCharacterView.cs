using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

/// <summary>
///     会話キャラクター立ち絵を扱うビュー
/// </summay>
public class TalkCharacterView : MonoBehaviour
{

    /// ==================================================
    /// Members
    /// ==================================================

    // Prefab内GameObject
    public Image characterImage;


    /// ==================================================
    /// Trigger method
    /// ==================================================

    /// <summary>
    ///     インスタンス生成時に実行
    /// </summary>
    void Start() {
        this.characterImage.sprite = Resources.Load<Sprite>(CommonDefine.NULL_IMAGE_PATH);
    }


    /// ==================================================
    /// Public method
    /// ==================================================

    /// <summary>
    ///     立ち絵を変更する
    /// </summary>
    public void SetNpcIllust(string imagePath) {
        this.characterImage.sprite = Resources.Load<Sprite>(imagePath);
    }

    /// <summary>
    ///      立ち絵を削除する
    /// </summary>
    public void ClearNpcIllust() {
        this.characterImage.sprite = Resources.Load<Sprite>(CommonDefine.NULL_IMAGE_PATH);
    }
}