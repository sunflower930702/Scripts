using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommonEquipActionModel : MonoBehaviour
{
    public PlayerModel playerModel;
    public InventoryController inventoryController;

    public bool checkEquipable(int equipPartyId) {

        if (equipPartyId == CommonDefine.PLAYER_PARTY_ID) {
            return playerModel.checkEquipable();
        } else {
            return playerModel.checkEquipableNpc(equipPartyId);
        }
    }

    public void equipItem(InventoryHaveItemData data, int equipPartyId) {

        if (equipPartyId == CommonDefine.PLAYER_PARTY_ID) {
            playerModel.equipItem(data.ItemTable, data.ItemId);
            inventoryController.updateInventoryMenu();
        } else {
            playerModel.equipItemNpc(data.ItemTable, data.ItemId, equipPartyId);
            inventoryController.updateInventoryMenu();
        }
    }
}
