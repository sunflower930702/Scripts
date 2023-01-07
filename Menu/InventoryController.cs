using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour
{

    private PlayerModel playerModel;
    private InventoryModel inventoryModel;
    private InventoryItemViewModel inventoryItemViewModel;

    public GameObject inventoryPrefab;
    public GameObject itemViewPrefab;

    private bool isActive = false;


    // ==================================================
    // Publicメソッド
    // ==================================================

    public void initInventoryMenu() {

        isActive = true;

        playerModel = GameObject.Find(CommonDefine.PLAYER_NAME).GetComponent<PlayerModel>();

        inventoryModel = initInventory();
        inventoryItemViewModel = initItemView();
        inventoryModel.linkItemViewModel(inventoryItemViewModel);
        inventoryItemViewModel.setPlayerModel(playerModel);

        updateInventoryMenu();
    }

    public void updateInventoryMenu() {

        List<InventoryHaveItemData> playerHaveItemList = playerModel.getInventoryHaveItemList();

        inventoryModel.update(playerHaveItemList);
        inventoryItemViewModel.setNewItemData(playerHaveItemList);
    }

    public void closeInventoryMenu() {

        Destroy(inventoryModel.gameObject);
        isActive = false;
    }

    public bool checkIsActive() {
        return isActive;
    }


    /// ==================================================
    /// Privateメソッド
    /// ==================================================

    private InventoryModel initInventory() {

        // inventoryパネルを生成
        GameObject inventoryObj = Instantiate(inventoryPrefab);
        InventoryModel tmpInventoryModel = inventoryObj.GetComponent<InventoryModel>();
        tmpInventoryModel.init();

        return tmpInventoryModel;
    }

    private InventoryItemViewModel initItemView() {

        // itemViewを生成
        GameObject tmpItemView = Instantiate(itemViewPrefab, itemViewPrefab.transform.position, Quaternion.identity);
        tmpItemView.transform.SetParent(inventoryModel.gameObject.transform, false);

        InventoryItemViewModel tmpInventoryItemViewModel = tmpItemView.GetComponent<InventoryItemViewModel>();
        tmpInventoryItemViewModel.initItemView();

        return tmpInventoryItemViewModel;
    }
}
