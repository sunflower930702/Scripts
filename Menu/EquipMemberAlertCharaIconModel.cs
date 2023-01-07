using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EquipMemberAlertCharaIconModel : MonoBehaviour
{
    public int charaIconId;
    public InventoryHaveItemData currentItemData;

    public Image charaIconImage;

    public void init(List<PartyData> partyDataList, InventoryHaveItemData itemData) {
        currentItemData = itemData;

        foreach (PartyData partyData in partyDataList) {

            if (partyData.PartyNPCId == charaIconId) {
                charaIconImage.sprite = Resources.Load<Sprite>(partyData.IconImage);
            }
        }
    }

    public void onClickCharaIcon() {

        EquipActionController equipActionController = GameObject.Find(CommonDefine.ACTION_CONTROLLER_NAME).GetComponent<EquipActionController>();
        equipActionController.execAction(currentItemData, charaIconId);

        Destroy(this.transform.parent.gameObject);
    }
}
