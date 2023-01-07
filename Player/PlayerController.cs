using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{

    // 各種メニューが表示可能か
    public bool canMenu;


    // UI Controllers
    public InventoryController inventoryController;
    public TalkController talkController;
    public EquipMenuController equipMenuController;


    void Start() {
        canMenu = true;
    }


    void Update() {

        // 毎秒Rayを射出
        RaycastHit hit;
        Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);

        GameObject target;
        string hitTag;
        if (Physics.Raycast(ray, out hit, 2.5f)) {

            hitTag = hit.collider.gameObject.tag;
            target = hit.collider.gameObject;
        } else {

            hitTag = "none";
            target = null;
        }
    
        if (Keyboard.current[Key.F].wasPressedThisFrame) {

            switch (hitTag) {
                case "NPC":
                    if (canMenu) {
                        TalkNPCData tmpTalkNPCData = target.GetComponent<NPCModel>().getTalkData();

                        talkController.initTalkMenu(tmpTalkNPCData, true);
                        canMenu = false;
                    }
                    break;
            }

            if (talkController.checkIsActive() == false) {
                talkController.closeTalkMenu();
                canMenu = true;
            }

            return;
        }



        if (Keyboard.current[Key.E].wasPressedThisFrame) {
            if (inventoryController.checkIsActive() == false) {
                if (canMenu) {

                    inventoryController.initInventoryMenu();
                    canMenu = false;
                }
            }else {

                inventoryController.closeInventoryMenu();
                canMenu = true;
            }

            return;
        }


        if (Keyboard.current[Key.H].wasPressedThisFrame) {
            if (equipMenuController.checkIsActive() == false) {
                if (canMenu) {

                    equipMenuController.initEquipMenu();
                    canMenu = false;
                }
            }else {

                equipMenuController.closeInventoryMenu();
                canMenu = true;
            }

            return;
        }
    }
}
