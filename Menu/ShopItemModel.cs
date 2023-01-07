using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopItemModel : MonoBehaviour
{
    public TextMeshProUGUI nameText;
    public Image iconImage;
    public TextMeshProUGUI valueText;

    private ShopNPCHaveItemData myNPCItemData;
    private ShopPlayerHaveItemData myPlayerItemData;

    private ShopModel shopModel;


    public void setModel(ShopModel model) {
        shopModel = model;
    }

    public void updateItem(ShopNPCHaveItemData itemData) {

        myNPCItemData = itemData;

        nameText.text = myNPCItemData.ItemName;
        iconImage.sprite = Resources.Load<Sprite>(myNPCItemData.ItemIconPath);
        valueText.text = myNPCItemData.Buy.ToString() + " Gold";
    }
    public void updateItem(ShopPlayerHaveItemData itemData) {

        myPlayerItemData = itemData;

        nameText.text = myPlayerItemData.ItemName;
        iconImage.sprite = Resources.Load<Sprite>(myPlayerItemData.ItemIconPath);
        valueText.text = "所持数x" + itemData.ItemCount.ToString() + "   " +  myPlayerItemData.Cell.ToString() + " Gold";
    }

    public void onClickShopItem() {
        switch (shopModel.getShopMode()) {
            case ShopMode.Buy:
                shopModel.setConfirmMenu(myNPCItemData);
                break;
            case ShopMode.Cell:
                shopModel.setConfirmMenu(myPlayerItemData);
                break;
        }
    }
}
