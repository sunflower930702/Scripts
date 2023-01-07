using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MapMoveButtonModel : MonoBehaviour
{
    public string targetSence = "";

    public void moveSence() {

        if (targetSence != "") {
            SceneManager.LoadScene(this.targetSence);
        }
    }
}
