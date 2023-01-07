using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipMemberAlertModel : MonoBehaviour
{

    public List<EquipMemberAlertCharaIconModel> equipMemberAlertCharaIconModels;

    private PlayerModel playerModel;

    public void setPlayerModel(PlayerModel model) {
        playerModel = model;
    }

    public void initEquipMemberAlert(InventoryHaveItemData data) {

        foreach (EquipMemberAlertCharaIconModel equipMemberAlertCharaIconModel in equipMemberAlertCharaIconModels) {
            List<PartyData> partyData = playerModel.getPartyData();
            equipMemberAlertCharaIconModel.init(partyData, data);
        }
    }
}
