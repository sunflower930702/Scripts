using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EquipMenuItemBoxModel : MonoBehaviour
{

    public int myBoxNo;
    private bool isEmpty;
    private EquipMenuHaveItemData myItemData;

    public Image itemImage;
    public TextMeshProUGUI itemName;
    public GameObject underLine;
    public GameObject dropButton;

    public EquipMenuModel equipMenuModel;

    /// ==================================================
    /// Publicメソッド
    /// ==================================================


    public void updateItemBox(EquipMenuHaveItemData itemData) {

        isEmpty = itemData.IsEmpty;
        myItemData = itemData;
        itemImage.sprite = Resources.Load<Sprite>(myItemData.ItemIconPath);
        itemName.text = myItemData.ItemName;

        if (isEmpty) {
            itemImage.color = new Color32(255, 255, 255, 0);
            underLine.GetComponent<Image>().color = new Color32(255, 255, 255, 0);
            dropButton.SetActive(false);
        } else {
            itemImage.color = new Color32(255, 255, 255, 255);
            underLine.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
            dropButton.SetActive(true);
        }
    }

    public void onClickDropButton() {

        equipMenuModel.dropEquipItem(myBoxNo);
    }
}
