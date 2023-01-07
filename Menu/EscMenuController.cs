using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class EscMenuController : MonoBehaviour
{

    void Update()
    {
        if (Keyboard.current[Key.Escape].wasPressedThisFrame) {
            Application.Quit();
        }
    }
}
