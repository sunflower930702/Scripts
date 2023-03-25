using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
///     NPCに関する処理を保持するモデル
/// </summary>
public class NpcModel : MonoBehaviour
{

    /// ==================================================
    /// Members
    /// ==================================================

    // 別オブジェクトへの参照
    // Databases
    public NpcTable npcTable;

    /// ==================================================
    /// Public Method
    /// ==================================================

    /// <summary>
    ///     NPCのデータを一件取得
    /// </summary>
    public NpcRecordData GetNpcData(int id) {
        return npcTable.GetRecordData(id);
    }
}