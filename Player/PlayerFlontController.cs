using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerFlontController : MonoBehaviour
{

    /*

    public GameObject playerObject;
    public PlayerController playerController;

    public List<GameObject> flontObjects;
    public List<GameObject> flontNPCs;


    void Update()
    {
        Vector3 playerPos = playerObject.transform.position;

        bool isChange = false;
        float xPos = 0;
        float yPos = 0;
        float zRot = 0;

        if (Input.GetKey(KeyCode.W)) {
            isChange = true;
            yPos = 15.0f;
            zRot = 0;
        } else if (Input.GetKey(KeyCode.S)) {
            isChange = true;
            yPos = -15.0f;
            zRot = 180.0f;
        }

        if (Input.GetKey(KeyCode.A)) {
            
            xPos = -15.0f;

            if (yPos == 15.0f) {
                zRot = 45.0f;
            } else if (yPos == -15.0f) {
                zRot = 135.0f;
            } else {
                zRot = 90.0f;
            }
            isChange = true;
        } else if (Input.GetKey(KeyCode.D)) {

            xPos = 15.0f;
            if (yPos == 15.0f) {
                zRot = -45.0f;
            } else if (yPos == -15.0f) {
                zRot = -135.0f;
            } else {
                zRot = -90.0f;
            }
            isChange = true;
        }

        if (isChange && playerController.canMove) {
            Vector3 myPosition = new Vector3(xPos, yPos, 0);
            Vector3 myRotation = new Vector3(0, 0, zRot);

            this.transform.position = playerPos + myPosition;
            this.transform.rotation = new Quaternion(0,0,0,0);
            this.transform.Rotate(myRotation);
        }

        if (Input.GetKeyDown(KeyCode.Space)) {
            if (flontObjects.Count > 0) {
                if (playerController.canMenu) {

                    bool isDestroy = flontObjects[0].GetComponent<ObjectModel>().isDestory;
                    flontObjects[0].GetComponent<ObjectModel>().myAction();

                    if (!isDestroy) {
                        flontObjects.RemoveAt(0);
                    }
                }

                return;
            }
        }

        if (Input.GetKeyDown(KeyCode.F)) {
            if (flontNPCs.Count > 0) {
                if (playerController.canMenu) {
                    if (playerController.talkController.checkIsActive() == false) {

                        TalkNPCData tmpTalkNPCData = flontNPCs[0].GetComponent<NPCModel>().getTalkData();

                        playerController.talkController.initTalkMenu(tmpTalkNPCData);
                        playerController.canMenu = false;
                        playerController.canMove = false;
                    } else {

                        playerController.talkController.closeTalkMenu();
                        playerController.canMenu = true;
                        playerController.canMove = true;
                    }
                }
            }

            return;
        }
    }

    public void OnTriggerEnter2D(Collider2D other) {

        switch (other.gameObject.tag) {
            case "object":
                flontObjects.Add(other.gameObject);
                break;
            case "NPC":
                flontNPCs.Add(other.gameObject);
                break;
        }
    }

    public void OnTriggerExit2D(Collider2D other) {

        switch (other.gameObject.tag) {
            case "object":
                flontObjects.Remove(other.gameObject);
                break;
            case "NPC":
                flontNPCs.Remove(other.gameObject);
                break;
        }
    }

    */
}
