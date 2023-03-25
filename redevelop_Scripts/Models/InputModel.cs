using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
///     物理入力に関する処理を保持するモデル
/// </summary>
public class InputModel : MonoBehaviour
{

    /// ==================================================
    /// Properties
    /// ==================================================

    /// <summary>
    ///     入力可能フラグ
    /// </summary>
    public bool InputableFlag { get; set; }


    /// ==================================================
    /// Trigger method
    /// ==================================================

    /// <summary>
    ///     インスタンス生成時に実行
    /// </summary>
    void Start() {
        this.InputableFlag = true;
    }
}