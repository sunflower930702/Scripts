using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantUseActionModel : MonoBehaviour
{
    private ItemDatabaseTable myTable = ItemDatabaseTable.Plant;

    public PlayerModel playerModel;
    public InventoryController inventoryController;

    public void testUse(InventoryHaveItemData data) {
        playerModel.deleteItem(data.ListNo, 1);
        inventoryController.updateInventoryMenu();
    }
}
