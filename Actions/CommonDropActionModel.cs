using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommonDropActionModel : MonoBehaviour
{
    public PlayerModel playerModel;
    public InventoryController inventoryController;

    public void dropItem(InventoryHaveItemData data) {
        playerModel.deleteItem(data.ListNo, 1);
        inventoryController.updateInventoryMenu();
    }
}
