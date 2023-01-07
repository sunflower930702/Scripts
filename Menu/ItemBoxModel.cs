using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public enum ItemBoxProcess {
    ItemView = 0,
    Shop,
    WearHouse
}

public class ItemBoxModel : MonoBehaviour
{

    private int myBoxNo;
    private bool isEmpty;
    private InventoryHaveItemData myItemData;

    private ItemBoxProcess myProcess;
    private InventoryItemViewModel inventoryItemViewModel;

    public TextMeshProUGUI countText;
    public Image iconImage;


    /// ==================================================
    /// Publicメソッド
    /// ==================================================

    public void initItemBox(int boxNo) {

        myBoxNo = boxNo;
        isEmpty = true;
    }

    public void setItemViewModel(InventoryItemViewModel model) {
        inventoryItemViewModel = model;
        myProcess = ItemBoxProcess.ItemView;
    }
    public void setShopListModel() {
        myProcess = ItemBoxProcess.Shop;
    }

    public void updateInventoryItemBox(InventoryHaveItemData itemData) {

        isEmpty = itemData.IsEmpty;
        myItemData = itemData;
        countText.text = myItemData.ItemCount;
        iconImage.sprite = Resources.Load<Sprite>(myItemData.ItemIconPath);

        if (isEmpty) {
            iconImage.color = new Color32(255, 255, 255, 0);
        } else {
            iconImage.color = new Color32(255, 255, 255, 255);
        }
    }

    public void onClickItemBox() {
        switch (myProcess) {
            case ItemBoxProcess.ItemView:
                inventoryItemViewModel.updateItemView(myItemData);
                break;
            case ItemBoxProcess.Shop:
                break;
            case ItemBoxProcess.WearHouse:
                break;
        }
    }
}
