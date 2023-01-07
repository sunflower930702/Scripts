using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraController : MonoBehaviour
{
    private Vector2 move;
    private GameObject cameraObject;
    public void OnCameraMove(InputAction.CallbackContext context)
    {
        move = context.ReadValue<Vector2>();
     }
    // Start is called before the first frame update
    void Start()
    {
        cameraObject = GameObject.Find("FPCamera");
    }

    // Update is called once per frame
    void Update()
    {
        const float Speed = 50f;
        transform.Rotate( new Vector3(0, move.x * Speed * Time.deltaTime, 0));
        float a = cameraObject.transform.eulerAngles.x - (move.y * Speed * Time.deltaTime);
        if ((a > -11f && a < 80f) || (a > 270 && a < 365)){
            cameraObject.transform.Rotate(- move.y * Speed * Time.deltaTime, 0, 0);
        }
        
    }
}
