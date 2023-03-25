using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using System.Linq;

/// <summary>
///     ショップを扱うコントローラ
/// </summary>
public class ShopController : MonoBehaviour
{

    /// ==================================================
    /// Members
    /// ==================================================

    // 別オブジェクトへの参照
    // Views
    public ShopWindowView shopWindowView;

    /// <summary>
    ///     表示中のショップウィンドウ
    /// </summary>
    public GameObject shopWindow;

    /// ==================================================
    /// Public method
    /// ==================================================

    /// <summary>
    ///     ショップウィンドウを表示
    /// </summary>
    public void Open(NpcTalkData opener) {


        this.shopWindowView.CreateList();

    }

    /// <summary>
    ///     ショップウィンドウが表示中かを返す
    /// </summary>
    public bool IsActiveShopkWindow() {
        return (this.shopWindow != null);
    }


}
