using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(InfiniteScroll))]
public class ShopItemControllerLimited : UIBehaviour, IInfiniteScrollSetup {

    public ShopModel shopModel;

    [SerializeField, Range(1, 999)]
    private int max = 30;

    public void OnPostSetupItems()
    {
        var infiniteScroll = GetComponent<InfiniteScroll>();
        infiniteScroll.onUpdateItem.AddListener(OnUpdateItem);
        GetComponentInParent<ScrollRect>().movementType = ScrollRect.MovementType.Elastic;

        var rectTransform = GetComponent<RectTransform>();
        var delta = rectTransform.sizeDelta;
        delta.y = infiniteScroll.itemScale * max;
        rectTransform.sizeDelta = delta;
    }

    public void OnUpdateItem(int itemCount, GameObject obj)
    {
        GameObject parentObject = this.transform.parent.gameObject;
        ShopModel targetShopModel = parentObject.transform.parent.gameObject.GetComponent<ShopModel>();

		Debug.Log(shopModel.getShopMode());
		switch (shopModel.getShopMode()) {
            case ShopMode.Buy:
                max = targetShopModel.curShopBuyItemList.Count;
                break;
            case ShopMode.Cell:
                max = targetShopModel.curShopCellItemList.Count;
                break;
        }

        if(itemCount < 0 || itemCount >= max) {
            obj.SetActive (false);
        }
        else {
            obj.SetActive (true);

            var item = obj.GetComponentInChildren<ShopItemModel>();
            item.setModel(shopModel);
            switch (shopModel.getShopMode()) {
                case ShopMode.Buy:
                    item.updateItem(targetShopModel.curShopBuyItemList[itemCount]);
                    break;
                case ShopMode.Cell:
                    item.updateItem(targetShopModel.curShopCellItemList[itemCount]);
                    break;
            }
        }
    }
}
