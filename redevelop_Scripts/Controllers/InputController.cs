using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
///     物理入力を扱うコントローラ
/// </summary>
public class InputController : MonoBehaviour
{

    /// ==================================================
    /// Members
    /// ==================================================

    // 別オブジェクトへの参照
    // Controllers
    public TalkController talkController;
    public InventoryController inventoryContoller;
    public EquipController equipController;

    // Models
    public InputModel inputModel;

    /// ==================================================
    /// Trigger method
    /// ==================================================

    /// <summary>
    ///     毎フレーム実行
    /// </summary>
    void Update() {

        // 動作可能状態か
        if (this.IsInputable()) {
            return;
        }


        // フォーカスがあたっているオブジェクト
        GameObject target = this.GetTarget();

        // Fキー
        if (Keyboard.current[Key.F].wasPressedThisFrame) {
            this.Action(target);
        }

        // Eキー
        if (Keyboard.current[Key.E].wasPressedThisFrame) {
            this.ViewInventory();
        }

        // Hキー
        if (Keyboard.current[Key.H].wasPressedThisFrame) {
            this.ViewEquip();
        }
    }


    /// ==================================================
    /// Private method
    /// ==================================================


    /// <summary>
    ///     入力可能状態か
    /// </summary>
    private IsInputable() {
        return inputModel.InputableFlag;
    }

    /// <summary>
    ///     フォーカスがあたっているオブジェクトを取得
    /// </summary>
    private GameObject GetTarget() {

        GameObject target;

        RaycastHit hit;
        Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);

        if (Physics.Raycast(ray, out hit, 2.5f) == false) {
            // 対象がいない場合
            return null;
        }

        return hit.collider.gameObject;
    }

    /// <summary>
    ///     アクションを起こす
    /// </summary>
    private void Action(GameObject target) {

        // 対象がいない場合は何もしない
        if (target == null) {
            return;
        }

        // 対象のタグによって処理を変更
        switch (target.tag) {
            case "NPC":
                inputModel.InputableFlag = false;
                talkController.Talk(target.GetComponent<NpcController>());
                break;
            default:
                break;
        }

        return;
    }

    /// <summary>
    ///     インベントリを表示
    /// </summary>
    private void ViewInventory() {

        inputModel.InputableFlag = false;
        inventoryContoller.View();
        return;
    }

    /// <summary>
    ///     装備メニューを表示
    /// </summary>
    private void ViewEquip() {

        inputModel.InputableFlag = false;
        equipController.View();
        return;
    }
}