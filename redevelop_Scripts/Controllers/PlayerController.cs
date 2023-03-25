using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMoveController : MonoBehaviour
{
    private Vector3 move;

    // Events
    public void OnMove(InputAction.CallbackContext context)
    {
        move = context.ReadValue<Vector2>();
        move = new Vector3(move.x,move.z,move.y);
        move = move.normalized;
    }

    void Start()
    {
        
    }

    void Update()
    {
        const float Speed = 2f;
        transform.Translate(move * Speed * Time.deltaTime);
    }


}
