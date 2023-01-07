using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EquipMenuCharaIconModel : MonoBehaviour {

    public int charaIconId;

    public EquipMenuModel equipMenuModel;
    public GameObject enableButton;
    public GameObject noEnableButton;
    public Image enableButtonImage;
    public Image noEnableButtonImage;

    private PartyData currentData;

    void Start() {
        if (charaIconId == CommonDefine.PLAYER_PARTY_ID) {
            enableButton.SetActive(true);
            noEnableButton.SetActive(false);
        } else {
            enableButton.SetActive(false);
            noEnableButton.SetActive(true);
        }
    }

    public void init(PartyData data) {

        currentData = data;

        enableButtonImage.sprite = Resources.Load<Sprite>(data.IconImage);
        noEnableButtonImage.sprite = Resources.Load<Sprite>(data.IconImage);
    }

    public void onClickCharaIcon() {

        equipMenuModel.updateCharaIcon(currentData);
        equipMenuModel.update(currentData.EquipData);
    }

    public void update(bool isEnable) {

        if (isEnable) {
            enableButton.SetActive(true);
            noEnableButton.SetActive(false);
        } else {
            enableButton.SetActive(false);
            noEnableButton.SetActive(true);        
        }
    }
}
