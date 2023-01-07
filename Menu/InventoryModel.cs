using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryModel : MonoBehaviour
{

    public GameObject itemBoxPrefab;

    private List<ItemBoxModel> itemBoxModels;

    private float itemBoxStartX = 125.0f;
    private float itemBoxStartY = 700.0f;

    private float diffX = 125.0f;
    private float diffY = 125.0f;


    /// ==================================================
    /// Publicメソッド
    /// ==================================================

    public void init() {

        itemBoxModels = new List<ItemBoxModel>();

        float x = itemBoxStartX;
        float y = itemBoxStartY;

        int count = 0;

        // itemBoxを等間隔で生成
        for (int i = 0; i < CommonDefine.INVENTORY_Y_SIZE; i++) {
            for (int j = 0; j< CommonDefine.INVENTORY_X_SIZE; j++) {

                GameObject tmpItemBox = Instantiate(itemBoxPrefab, new Vector3(x, y, 0), Quaternion.identity);
                tmpItemBox.transform.SetParent(this.gameObject.transform);
                ItemBoxModel tmpItemBoxModel = tmpItemBox.GetComponent<ItemBoxModel>();

                itemBoxModels.Add(tmpItemBoxModel);
                tmpItemBoxModel.initItemBox(count);

                x += diffX;
                count++;
            }

            x = itemBoxStartX;
            y -= diffY;
        }
    }

    public void linkItemViewModel(InventoryItemViewModel model) {
        foreach (ItemBoxModel item in itemBoxModels) {
            item.setItemViewModel(model);
        }
    }

    public void update(List<InventoryHaveItemData> itemList) {

        int i = 0;

        foreach (ItemBoxModel itemBoxModel in itemBoxModels) {

            itemBoxModel.updateInventoryItemBox(itemList[i]);
            i++;
        }
    }
}
