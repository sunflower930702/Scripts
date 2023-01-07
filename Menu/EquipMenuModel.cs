using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EquipMenuModel : MonoBehaviour
{

    public List<EquipMenuItemBoxModel> itemBoxModels;
    public List<EquipMenuCharaIconModel> charaIconModels;

    public Image charaStandImage;

    private int currentCharaIconId;

    private PlayerModel playerModel;


    /// ==================================================
    /// Publicメソッド
    /// ==================================================

    void Start() {
        currentCharaIconId = CommonDefine.PLAYER_PARTY_ID;
    }

    public void setPlayerModel(PlayerModel model) {
        playerModel = model;        
    }

    public void update(List<EquipMenuHaveItemData> itemList) {

        int i = 0;

        foreach (EquipMenuItemBoxModel itemBoxModel in itemBoxModels) {
            itemBoxModel.updateItemBox(itemList[i]);
            i++;
        }
    }

    public void initCharaIcon(List<PartyData> partyDataList) {

        foreach (PartyData partyData in partyDataList) {

            foreach (EquipMenuCharaIconModel charaIconModel in charaIconModels) {
                if (partyData.PartyNPCId == charaIconModel.charaIconId) {
                    charaIconModel.init(partyData);
                }
            }

            if (partyData.PartyNPCId == CommonDefine.PLAYER_PARTY_ID) {
                charaStandImage.sprite = Resources.Load<Sprite>(partyData.StandImage);
            }
        }
    }

    public void updateCharaIcon(PartyData clickData) {

        charaStandImage.sprite = Resources.Load<Sprite>(clickData.StandImage);

        foreach (EquipMenuCharaIconModel charaIconModel in charaIconModels) {
            charaIconModel.update(clickData.PartyNPCId == charaIconModel.charaIconId);
        }

        currentCharaIconId = clickData.PartyNPCId;
    }

    public void dropEquipItem(int boxNo) {

        if (currentCharaIconId == CommonDefine.PLAYER_PARTY_ID) {
            playerModel.unEquipItem(boxNo);
        } else {
            playerModel.unEquipItemNpc(boxNo, currentCharaIconId);
        }

        List<PartyData> partyDataList = playerModel.getPartyData();
        foreach (PartyData partyData in partyDataList) {

            foreach (EquipMenuCharaIconModel charaIconModel in charaIconModels) {
                if (partyData.PartyNPCId == charaIconModel.charaIconId) {
                    charaIconModel.init(partyData);
                }
            }

            if (partyData.PartyNPCId == currentCharaIconId) {
                update(partyData.EquipData);
            }
        }
    }
}
