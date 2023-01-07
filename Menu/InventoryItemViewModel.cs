using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventoryItemViewModel : MonoBehaviour
{

    private InventoryHaveItemData currentItemData;
    private bool isActive;

    public TextMeshProUGUI nameText;
    public TextMeshProUGUI contetntText;
    public Image imageBackImage;
    public Image imageMainImage;
    public Button actionButton;
    public Button dropButton;
    public TextMeshProUGUI actionButtonText;
    public TextMeshProUGUI dropButtonText;


    private string normalBackImage = "Interfaces/Inventory/RealityBackImage/N";
    private string rareBackImage = "Interfaces/Inventory/RealityBackImage/R";
    private string superRareBackImage = "Interfaces/Inventory/RealityBackImage/SR";
    private string superSuperRareBackImage = "Interfaces/Inventory/RealityBackImage/SSR";
    private string ultraRareBackImage = "Interfaces/Inventory/RealityBackImage/UR";
    private string blackBackImage = "Interfaces/Inventory/RealityBackImage/B";

    public GameObject equipMemberAlertPrefab;

    private PlayerModel playerModel;


    public void setPlayerModel(PlayerModel model) {
        playerModel = model;
    }

    public void initItemView() {

        nameText.text = "";
        contetntText.text = "";
        imageBackImage.sprite = Resources.Load<Sprite>(CommonDefine.NULL_IMAGE_PATH);
        imageMainImage.sprite = Resources.Load<Sprite>(CommonDefine.NULL_IMAGE_PATH);
        setActiveActionButton(false);
        setActiveDropButton(false);

        isActive = false;
    }

    public void updateItemView(InventoryHaveItemData itemData) {

        currentItemData = itemData;

        setActiveActionButton(false);
        setActiveDropButton(false);

        nameText.text = currentItemData.ItemName;
        contetntText.text = currentItemData.ItemContent;

        switch (itemData.ItemReality) {
            case ItemReality.None:
                imageBackImage.sprite = Resources.Load<Sprite>(CommonDefine.NULL_IMAGE_PATH);
                break;
            case ItemReality.N:
                imageBackImage.sprite = Resources.Load<Sprite>(normalBackImage);
                break;
            case ItemReality.R:
                imageBackImage.sprite = Resources.Load<Sprite>(rareBackImage);
                break;
            case ItemReality.SR:
                imageBackImage.sprite = Resources.Load<Sprite>(superRareBackImage);
                break;
            case ItemReality.SSR:
                imageBackImage.sprite = Resources.Load<Sprite>(superSuperRareBackImage);
                break;
            case ItemReality.UR:
                imageBackImage.sprite = Resources.Load<Sprite>(ultraRareBackImage);
                break;
            case ItemReality.B:
                imageBackImage.sprite = Resources.Load<Sprite>(blackBackImage);
                break;
        }
        imageMainImage.sprite = Resources.Load<Sprite>(currentItemData.ItemImagePath);


        isActive = !itemData.IsEmpty;

        if (isActive) {
            switch (currentItemData.ItemType) {
                case ItemType.Use:
                    setActiveDropButton(true);
                    setActiveActionButton(true);
                    actionButtonText.text = "使う";
                    break;
                case ItemType.Equip:
                    setActiveDropButton(true);
                    setActiveActionButton(true);
                    actionButtonText.text = "装備する";
                    break;
                case ItemType.None:
                    setActiveDropButton(true);
                    setActiveActionButton(false);
                    break;
                default:
                    setActiveDropButton(true);
                    setActiveActionButton(false);
                    break;
            }
        }
    }

    public void setNewItemData(List<InventoryHaveItemData> playerHaveItemList) {

        if (isActive == true) {
            int listNo = currentItemData.ListNo;
            updateItemView(playerHaveItemList[listNo]);
        }
    }

    public void onClickDropButton() {

        DropActionController dropActionController = GameObject.Find(CommonDefine.ACTION_CONTROLLER_NAME).GetComponent<DropActionController>();
        dropActionController.execAction(currentItemData);
    }

    public void onClickActionButton() {

        switch (currentItemData.ItemType) {
            case ItemType.Use:
                UseActionController useActionController = GameObject.Find(CommonDefine.ACTION_CONTROLLER_NAME).GetComponent<UseActionController>();
                useActionController.execAction(currentItemData);
                break;
            case ItemType.UseDelete:
                // UseActionController useActionController = GameObject.Find(CommonDefine.ACTION_CONTROLLER_NAME).GetComponent<UseActionController>();
                // useActionController.execAction(currentItemData);
                break;
            case ItemType.Equip:

                GameObject tmpEquipMemberAlert = Instantiate(equipMemberAlertPrefab, equipMemberAlertPrefab.transform.position, Quaternion.identity);
                tmpEquipMemberAlert.transform.SetParent(this.transform.parent.gameObject.transform, false);

                EquipMemberAlertModel tmpModel = tmpEquipMemberAlert.GetComponent<EquipMemberAlertModel>();
                tmpModel.setPlayerModel(playerModel);
                tmpModel.initEquipMemberAlert(currentItemData);
                break;
            default:
                break;
        }
    }


    private void setActiveActionButton(bool status) {

        actionButton.enabled = status;
        actionButton.GetComponent<Image>().enabled = status;
        actionButtonText.enabled = status;
    }

    private void setActiveDropButton(bool status) {

        dropButton.enabled = status;
        dropButton.GetComponent<Image>().enabled = status;
        dropButtonText.enabled = status;
    }
}
