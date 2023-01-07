using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract class ObjectModel : MonoBehaviour
{
    public ItemDatabaseTable itemTable;
    public int itemId;
    public int itemCount;

    // アクション後に自分で消えるか
    public bool isDestory;

    public abstract void myAction();

    // プレイヤーに所持品を加える
    protected int addPlayerItem (ItemDatabaseTable table, int id, int count) {

        return GameObject.Find(CommonDefine.PLAYER_NAME).GetComponent<PlayerModel>().addItem(table, id, count);
    }
}
