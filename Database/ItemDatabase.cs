using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ItemDatabase : MonoBehaviour
{

    // テーブル配列
    private List<ArrayList>[] itemTables;


    /// ==================================================
    /// トリガーメソッド
    /// ==================================================

    void Awake() {
        setTable();
    }


    /// ================================================== 
    /// Publicメソッド
    /// ==================================================

    public ItemData getItemtData(ItemDatabaseTable table, int id) {

        ItemData result = new ItemData();

        ArrayList dataArrayList = itemTables[(int)table][id];
        result.setData(dataArrayList);

        return result;
    }


    /// ==================================================
    /// privateメソッド
    /// ==================================================

    private void setTable() {

        int size = ItemDatabaseTable.GetNames(typeof(ItemDatabaseTable)).Length;
        itemTables = new List<ArrayList>[size];

        for (int i = 0; i < size; i++) {
            itemTables[i] = readTableCsv("Assets/Tables/" + (ItemDatabaseTable)ItemDatabaseTable.ToObject(typeof(ItemDatabaseTable), i) + ".csv");
        }
    }

    private List<ArrayList> readTableCsv(string csvPath) {

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
