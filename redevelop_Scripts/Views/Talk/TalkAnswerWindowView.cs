using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

/// <summary>
///     会話ウィンドウを扱うビュー
/// </summary>
public class TalkAnswerWindowView : MonoBehaviour
{

    /// ==================================================
    /// Members
    /// ==================================================

    // 別オブジェクトへの参照
    // Prefabs
    public GameObject answerPrefab;

    /// <summary>
    ///     現在設定中の解答データリスト
    /// </summary>
    public List<AnswerData> answerDataList;

    /// <summary>
    ///     現在設定中の解答オブジェクトリスト
    /// </summary>
    public List<GameObject> answerObjList;

    /// <summary>
    ///     プレイヤーが選択した解答データ
    /// </summary>
    private AnswerData confirmAnswerData;


    /// ==================================================
    /// Trigger Method
    /// ==================================================

    /// <summary>
    ///     インスタンス生成時に実行
    /// </summary>
    void Start() {
        this.confirmAnswerData = null;
        answerList = new List<AnswerData>();
    }


    /// ==================================================
    /// Public Method
    /// ==================================================

    /// <summary>
    ///     選択肢の解答を追加
    /// </summary>
    public void AddAnswer(string str, int to) {

        AnswerData answerData = new AnswerData();
        answerData.AnswerNo = count(answerDataList);
        answerData.AnswerText = str;
        answerData.JumpNo = to;

        this.answerDataList.Insert(answerData.AnswerNo, answerData);
    }

    /// <summary>
    ///     質問が解答されたか
    /// </summary>
    public bool IsGetAnswer() {
        return (this.confirmAnswerData != null);
    }

    /// <summary>
    ///     選択された解答を返す
    /// </summary>
    public AnswerData GetAnswer() {
        return this.confirmAnswerData;
    }

    /// <summary>
    ///     解答を一つ選択する
    /// </summary>
    public void SetAnswer(int no) {
        this.confirmAnswerData = this.answerDataList[no];
    }

    /// <summary>
    ///     現在設定中の解答で質問を行う
    /// </summary>
    public void ShowAnswers() {

        float height = 85.0f;

        foreach (AnswerData answerData in this.answerDataList) {

            // 解答のプレハブ実体化
            GameObject answerObject = Instantiate(answerPrefab);
            this.answerObjList.Add(answerObject);

            // 位置設定
            answerObject.transform.SetParent(this.gameObject.transform, false);
            answerObject.transform.Translate(0, height * answerData.AnswerNo, 0);

            // 初期設定
            answerObject.gameObject.GetComponent<TalkAnswerBoxView>().SetAnswerData(answerData);
        }
    }

    /// <summary>
    ///     選択肢を削除
    /// </summary>
    public void ClearAnswer() {

        foreach (GameObject answerObj in this.answerObjList) {
            Destroy(answerObj);
        }

        this.answerDataList = new List<AnswerData>();
        this.answerObjList = new List<GameObject>(); 
        this.confirmAnswerData = null;
    }
}