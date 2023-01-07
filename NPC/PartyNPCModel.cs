using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PartyNPCModel : MonoBehaviour
{
    public int partyNPCId;

    private List<EquipItemData> equipItemList;

    public ItemDatabase itemDatabase;

    // TODO 取得方法
    public string charaIconImagePath;
    public string charaImagePath; 

    void Start() {
        initEquipItemList();
    }


    public bool checkEquipableNpc() {

        int count = 0;

        foreach (EquipItemData equipItemData in equipItemList) {
            if (equipItemData.IsEmpty == false) {
                count++;
            }
        }

        if (count >= CommonDefine.EQUIP_SIZE) {
            return false;
        }

        return true;
    }

    public void equipItem(ItemDatabaseTable table, int id) {

        bool isEquiped = false;

        List<EquipItemData> tmpList = new List<EquipItemData>();

        foreach (EquipItemData equipItemData in equipItemList) {
            if (equipItemData.IsEmpty && isEquiped == false) {

                equipItemData.ItemTable = table;
                equipItemData.ItemId = id;
                equipItemData.IsEmpty = false;

                isEquiped = true;
            }
            tmpList.Add(equipItemData);
        }

        equipItemList = tmpList;
    }

    public void unEquipItem(int listNo) {

        equipItemList[listNo].setEmptyItemData();

        List<EquipItemData> tmpList = new List<EquipItemData>();
        foreach (EquipItemData equipItemdata in equipItemList) {
            if (equipItemdata.IsEmpty == false) {
                tmpList.Add(equipItemdata);
            }
        }
        foreach (EquipItemData equipItemdata in equipItemList) {
            if (equipItemdata.IsEmpty == true) {
                tmpList.Add(equipItemdata);
            }
        }

        equipItemList = tmpList;
    }

    public List<EquipMenuHaveItemData> getEquipItemList() {

        List<EquipMenuHaveItemData> result = new List<EquipMenuHaveItemData>();

        int max = CommonDefine.EQUIP_SIZE;

        for (int i = 0; i < max; i++) {
            EquipMenuHaveItemData tmpItemData = new EquipMenuHaveItemData();

            if (equipItemList[i].IsEmpty) {
                tmpItemData.setEmptyItemData();
                tmpItemData.ListNo = i;
            } else {
                ItemData dbItemData = itemDatabase.getItemtData(equipItemList[i].ItemTable, equipItemList[i].ItemId);

                tmpItemData.ItemTable = equipItemList[i].ItemTable;
                tmpItemData.ItemId = equipItemList[i].ItemId;
                tmpItemData.ItemName = dbItemData.ItemName;
                tmpItemData.ItemIconPath = dbItemData.ItemIconPath;
                tmpItemData.IsEmpty = false;
            }

            result.Add(tmpItemData);
        }

        return result;
    }

    public void initEquipItemList() {

        equipItemList = new List<EquipItemData>();

        int listSize = CommonDefine.EQUIP_SIZE;
        for (int i = 0; i < listSize; i++) {
            EquipItemData tmpItemData = new EquipItemData();
            tmpItemData.setEmptyItemData();

            equipItemList.Add(tmpItemData);
        }
    }

    public PartyData getPartyData() {

        PartyData menuData = new PartyData();
        menuData.PartyNPCId = partyNPCId;
        menuData.StandImage = charaImagePath;
        menuData.IconImage = charaIconImagePath;
        menuData.EquipData = getEquipItemList();

        return menuData;
    }
}
