using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ConfirmModel : MonoBehaviour
{
    public TextMeshProUGUI message;
    public TextMeshProUGUI countText;
    public int count;
    public TextMeshProUGUI optionCountText;

    private ShopModel shopModel;
    private ShopNPCHaveItemData curShopNPCItemData;
    private ShopPlayerHaveItemData curShopPlayerItemData;

    private int min;
    private int max;

    private int defaultMin = 0;
    private int defaultMax = 999;

    public void init() {
        min = defaultMin;
        max = defaultMax;

        message.text = "";
        count = min;
        countText.text = count.ToString();
        optionCountText.text = "";
    }

    public void setMax(int val) {
        max = val;
    }

    public void setShopItemData(ShopNPCHaveItemData itemData) {
        curShopNPCItemData = itemData;
    }
    public void setShopItemData(ShopPlayerHaveItemData itemData) {
        curShopPlayerItemData = itemData;
    }
    public void setShopModel(ShopModel model) {
        shopModel = model;
    }

    public void setMessage(string msg) {
        message.text = msg;
    }

    public void onClickPlusButton() {
        if (count < max) {
            count++;
            countText.text = count.ToString();
            switch (shopModel.getShopMode()) {
                case ShopMode.Buy:
                    optionCountText.text = "(-" + (curShopNPCItemData.Buy * count).ToString() + " Gold)";
                    break;
                case ShopMode.Cell:
                    optionCountText.text = "(+" + (curShopPlayerItemData.Cell * count).ToString() + " Gold)";
                    break;
            }
        }
    }

    public void onClickMinusButton() {
        if (count > min) {
            count--;
            countText.text = count.ToString();
            switch (shopModel.getShopMode()) {
                case ShopMode.Buy:
                    optionCountText.text = "(-" + (curShopNPCItemData.Buy * count).ToString() + " Gold)";
                    break;
                case ShopMode.Cell:
                    optionCountText.text = "(+" + (curShopPlayerItemData.Cell * count).ToString() + " Gold)";
                    break;
            }
        }
    }

    public void onClickConfirmButton() {
        switch (shopModel.getShopMode()) {
            case ShopMode.Buy:
                shopModel.buyConfirm(curShopNPCItemData, count);
                break;
            case ShopMode.Cell:
                shopModel.cellConfirm(curShopPlayerItemData, count);
                break;
        }
    }
}
