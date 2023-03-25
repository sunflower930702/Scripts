using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

/// <summary>
///     ショップウィンドウを扱うビュー
/// </summary>
public class ShopWindowView : MonoBehaviour
{

    /// ==================================================
    /// Member
    /// ==================================================

    // 別オブジェクトへの参照
    // Prefabs
    public GameObject shopListPrefab;


    /// ==================================================
    /// Public method
    /// ==================================================

    public void CreateList() {

        GameObject shopListObj = Instantiate(shopListPrefab, shopListPrefab.transform.position, Quaternion.identity);
        shopListObj.transform.SetParent(this.gameObject.transform, false);
    }
}
