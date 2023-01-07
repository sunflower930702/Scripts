using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(InfiniteScroll))]
public class ItemControllerLimited : UIBehaviour, IInfiniteScrollSetup {

	[SerializeField, Range(1, 999)]
	private int max = 30;

	public void OnPostSetupItems()
	{

	}

	public void OnUpdateItem(int itemCount, GameObject obj)
	{

	}
}
