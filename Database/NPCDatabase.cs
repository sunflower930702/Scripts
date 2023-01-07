using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;


public class NPCDatabase : MonoBehaviour
{
    // テーブル
    private List<ArrayList> NPCTable;

    void Awake() {
        setTable();
    }

    public NPCData getNPCData(int id) {

        NPCData result = new NPCData();

        ArrayList dataArrayList = NPCTable[id];
        result.setData(dataArrayList);

        return result;
    }

    private void setTable() {

        NPCTable = readTableCsv("Assets/Tables/NPC.csv");
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