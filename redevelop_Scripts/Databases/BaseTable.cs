using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

/// <summary>
///     データベーステーブルとして振る舞う基底クラス
/// </summary>
public abstract class BaseTable : MonoBehaviour
{

    /// ==================================================
    /// Member
    /// ==================================================

    /// <summary>
    ///     扱う対象のテーブル
    /// </summary>
    protected string table = "";

    /// <summary>
    ///     レコードのリスト
    /// </summary>
    protected List<RecordData> recordDataList;


    /// ==================================================
    /// Public method
    /// ==================================================

    /// <summary>
    ///     テーブルを設定する
    /// </summary>
    public string SetTable(string t) {
        this.table = t;
        this.SetRecordListFromCsv();
    }

    /// <summary>
    ///     レコード情報を返す
    /// </summary>
    /// 
    public RecordData GetRecordData(int id) {

        if (this.table == "") {
            return null;
        }

        return this.recordDataList[id];
    }


    /// ==================================================
    /// Protected method
    /// ==================================================

    /// <summary>
    ///     レコード情報のリストをCSVをもとに設定
    /// </summary>
    protected abstract void SetRecordListFromCsv();


    /// <summary>
    ///     CSVを読み込んで、ArrayList型で返す
    /// </summary>
    protected List<ArrayList> ReadTableCsv(string csvPath) {

        List<ArrayList> result = new List<ArrayList>();

        StreamReader stream = new StreamReader(csvPath);
        bool isFirst = true;
        while (!stream.EndOfStream) {

            if (isFirst) {
                isFirst = false;
                continue;
            }

            string line = stream.ReadLine();
            string[] values = line.Split(',');

            ArrayList resultRecord = new ArrayList();
            foreach (var val in values) {
                resultRecord.Add(val);
            }
            result.Add(resultRecord);
        }

        return result;
    }
}