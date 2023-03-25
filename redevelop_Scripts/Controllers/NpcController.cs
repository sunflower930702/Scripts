using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
///     NPCを扱うコントローラ
/// </summary>
public class NpcController : MonoBehaviour
{

    /// ==================================================
    /// Members
    /// ==================================================

    // 別オブジェクトへの参照
    // Models
    public NpcModel npcModel;

    /// <summary>
    ///     NPCのID
    /// </summary>
    public int id;


    /// ==================================================
    /// Trigger method
    /// ==================================================

    /// <summary>
    ///     インスタンス生成時に実行
    /// </summary>
    void Start() {

        // TODO
        npcModel.GetTableData(this.id);
    }


    /// ==================================================
    /// Public method
    /// ==================================================

    /// <summary>
    ///     会話情報を取得
    /// </summary>
    public NpcTalkData GetNpcTalkData() {
        // TDOO メンバに固有情報を持って、その中身を使ってreturn
    }
}