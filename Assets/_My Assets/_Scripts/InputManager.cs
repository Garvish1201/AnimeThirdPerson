using UnityEngine;

public class InputManager : MonoBehaviour
{
    public float GetForwarMovementInput()
    {
        if (Input.GetKey(KeyCode.LeftShift))
            return Input.GetAxisRaw("Vertical") * 2;
        else
            return Input.GetAxisRaw("Vertical");
    }

    public float GetInputX()
    {
        return Input.GetAxisRaw("Horizontal");
    }

    public float MoveXMovement()
    {
        return Input.GetAxis("Mouse X");
    }
}
