using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

/// <summary>
///     アイテムのデータベーステーブルとして振る舞うクラス
/// </summary>
public class NpcTable : BaseTable
{

    /// ==================================================
    /// Protected method
    /// ==================================================

    /// <summary>
    ///     レコード情報のリストをCSVをもとに設定
    /// </summary>
    protected void SetRecordListFromCsv() {

        // リストを初期化
        this.recordDataList = new List<NpcRecordData>();

        // クラス継承先によりテーブル名が設定されている場合のみ
        if (this.table == null) {
            return;
        }

        List<ArrayList> csvLines = this.ReadTableCsv("Assets/Tables/" + this.table + ".csv");

        foreach (ArrayList csvLine in csvLines) {

            NpcRecordData tmpNpcRecordData = new NpcRecordData();

            tmpNpcRecordData.Id = int.Parse((string)csvLine[(int)NpcTableColumns.Id]);
            tmpNpcRecordData.UseLayer = int.Parse((string)csvLine[(int)NpcTableColumns.UseLayer]) == 1 ? true : false;
            tmpNpcRecordData.NPCName = (string)csvLine[(int)NpcTableColumns.NPCName];
            tmpNpcRecordData.NPCIllustPath = (string)csvLine[(int)NpcTableColumns.NPCIllustPath];
            tmpNpcRecordData.NPCIconPath = (string)csvLine[(int)NpcTableColumns.NPCIconPath];
            tmpNpcRecordData.TalkFilePath = (string)csvLine[(int)NpcTableColumns.TalkFilePath];
            tmpNpcRecordData.HaveItemFilePath = (string)csvLine[(int)NpcTableColumns.HaveItemFilePath];
            tmpNpcRecordData.ShopTalkFilePath = (string)csvLine[(int)NpcTableColumns.ShopTalkFilePath];

            this.recordDataList.Insert(tmpNpcRecordData.Id, tmpNpcRecordData);
        }

        return;
    }
}