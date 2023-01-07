using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropActionController : MonoBehaviour
{
    public CommonDropActionModel commonUseActionModel;

    public void execAction(InventoryHaveItemData data) {
        commonUseActionModel.dropItem(data);
    }
}
