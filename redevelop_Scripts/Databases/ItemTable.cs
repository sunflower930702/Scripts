using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

/// <summary>
///     アイテムのデータベーステーブルとして振る舞うクラス
/// </summary>
public class ItemTable : BaseTable
{

    /// ==================================================
    /// Protected method
    /// ==================================================

    /// <summary>
    ///     レコード情報のリストをCSVをもとに設定
    /// </summary>
    protected void SetRecordListFromCsv() {

        // リストを初期化
        this.recordDataList = new List<ItemRecordData>();

        // クラス継承先によりテーブル名が設定されている場合のみ
        if (this.table == null) {
            return;
        }

        List<ArrayList> csvLines = this.ReadTableCsv("Assets/Tables/" + this.table + ".csv");

        foreach (ArrayList csvLine in csvLines) {

            ItemRecordData tmpItemRecordData = new ItemRecordData();

            tmpItemRecordData.Id = int.Parse((string)csvLine[(int)ItemTableColumns.Id]);
            tmpItemRecordData.ItemName = (string)csvLine[(int)ItemTableColumns.ItemName];
            tmpItemRecordData.ItemContent = (string)csvLine[(int)ItemTableColumns.ItemContent];
            tmpItemRecordData.ItemType = (ItemType)(int.Parse((string)csvLine[(int)ItemTableColumns.ItemType]));
            tmpItemRecordData.ItemIconPath = (string)csvLine[(int)ItemTableColumns.ItemIconPath];
            tmpItemRecordData.ItemImagePath = (string)csvLine[(int)ItemTableColumns.ItemImagePath];
            tmpItemRecordData.ItemReality = (ItemReality)(int.Parse((string)csvLine[(int)ItemTableColumns.ItemReality]));
            tmpItemRecordData.HaveMax = int.Parse((string)csvLine[(int)ItemTableColumns.HaveMax]);
            tmpItemRecordData.Cell = int.Parse((string)csvLine[(int)ItemTableColumns.Cell]);
            tmpItemRecordData.Buy = int.Parse((string)csvLine[(int)ItemTableColumns.Buy]);

            this.recordDataList.Insert(tmpItemRecordData.Id, tmpItemRecordData);
        }

        return;
    }

}