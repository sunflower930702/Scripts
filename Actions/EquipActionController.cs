using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipActionController : MonoBehaviour
{

    public CommonEquipActionModel commonEquipActionModel;

    public void execAction(InventoryHaveItemData data, int equipPartyId) {

        // 装備判定
        bool isEquipable = true;
        switch (data.ItemTable) {
            default:
                isEquipable = commonEquipActionModel.checkEquipable(equipPartyId); 
                break;
        }

        if (isEquipable) {

            commonEquipActionModel.equipItem(data, equipPartyId);

            // 固有アクション
            switch (data.ItemTable) {
                default:
                    break;
            }
        } else {

            // 装備できない場合
        }
    }
}
