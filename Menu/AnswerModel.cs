using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AnswerModel : MonoBehaviour
{

    private AnswerData myAnswerData;

    private TalkModel talkModel;

    public TextMeshProUGUI answerText;


    public void initData(AnswerData answerData) {

        myAnswerData = answerData;
        answerText.text = answerData.AnswerText;
    }

    public void setTalkModel(TalkModel model) {
        talkModel = model;
    }

    public void onClickAnswerButton() {
        talkModel.answer(myAnswerData);
    }
}
