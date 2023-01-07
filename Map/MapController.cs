using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapController : MonoBehaviour
{
    public TalkController talkController;
    public NPCModel hiddenNPC;

    void Start() {

        if (hiddenNPC.talkFile != "") {
            TalkNPCData tmpTalkNPCData = hiddenNPC.getTalkData();
            talkController.initTalkMenu(tmpTalkNPCData, false);
        }
    }
}
