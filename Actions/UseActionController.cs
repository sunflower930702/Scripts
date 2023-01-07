using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseActionController: MonoBehaviour
{

    public CommonUseActionModel commonUseActionModel;
    public PlantUseActionModel plantUseActionModel;

    public void execAction(InventoryHaveItemData data) {

        switch (data.ItemTable) {
            case ItemDatabaseTable.Plant:
                execPlantAction(data);
                break;
            default:
                break;
        }
    }

    private void execPlantAction(InventoryHaveItemData data) {

        switch (data.ItemId) {
            case 0:
                plantUseActionModel.testUse(data);
                break;
            case 1:
                plantUseActionModel.testUse(data);
                break;
            case 2:
                plantUseActionModel.testUse(data);
                break;
            default:
                plantUseActionModel.testUse(data);
                break;
        }
    }
}