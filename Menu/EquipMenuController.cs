using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipMenuController : MonoBehaviour
{

    private PlayerModel playerModel;
    private EquipMenuModel equipMenuModel;

    public GameObject equipMenuPrefab;

    private bool isActive = false;

    // ==================================================
    // Publicメソッド
    // ==================================================

    public void initEquipMenu() {

        isActive = true;

        playerModel = GameObject.Find(CommonDefine.PLAYER_NAME).GetComponent<PlayerModel>();

        equipMenuModel = initEquip();
        equipMenuModel.setPlayerModel(playerModel);

        updateEquipMenu();
    }

    public void updateEquipMenu() {

        List<PartyData> partyData = playerModel.getPartyData();
        equipMenuModel.initCharaIcon(partyData);

        // 初回表示はプレイヤーから取得
        foreach (PartyData data in partyData) {
            if (data.PartyNPCId == CommonDefine.PLAYER_PARTY_ID) {
                equipMenuModel.update(data.EquipData);
            }
        }
    }

    public void closeInventoryMenu() {

        Destroy(equipMenuModel.gameObject);
        isActive = false;
    }

    public bool checkIsActive() {
        return isActive;
    }


    /// ==================================================
    /// Privateメソッド
    /// ==================================================

    private EquipMenuModel initEquip() {

        // 装備メニューを生成
        GameObject equipMenuObj = Instantiate(equipMenuPrefab);
        EquipMenuModel tmpEquipMenuModel = equipMenuObj.GetComponent<EquipMenuModel>();

        return tmpEquipMenuModel;
    }
}
