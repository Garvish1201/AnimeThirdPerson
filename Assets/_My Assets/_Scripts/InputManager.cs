using System.IO;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    [SerializeField] private Transform nintyDegree;
    [SerializeField] private Transform minNintyDegree;
    [SerializeField] private Transform fortyFiveDegree;
    [SerializeField] private Transform minFortyFiveDegree;
    [SerializeField] private Transform minOneEightyDegree;
    [SerializeField] private Transform oneThirtyFiveDegree;
    [SerializeField] private Transform twoTwoFiveDegree;

    public float GetForwardMovementInput()
    {
        if (Input.GetKey(KeyCode.LeftShift))
            return Input.GetAxisRaw("Vertical") * 1;
        else
            return Input.GetAxisRaw("Vertical");
    }

    public float GetSideMovementInput()
    {
        if (Input.GetKey(KeyCode.LeftShift))
            return Input.GetAxisRaw("Horizontal") * 1;
        else
            return Input.GetAxisRaw("Horizontal");
    }

    public float GetInputX()
    {
        return Input.GetAxisRaw("Horizontal");
    }

    public float MoveXMovement()
    {
        return Input.GetAxis("Mouse X");
    }

    public Quaternion GetOffsetRotation()
    {
        float directionX = Input.GetAxisRaw("Horizontal");
        float directionZ = Input.GetAxisRaw("Vertical");


        if (directionX == 1 && directionZ == 1)
        {
            return fortyFiveDegree.rotation;
        }
        else if (directionX == -1 && directionZ == 1)
        {
            return minFortyFiveDegree.rotation;
        }

        else if (directionX == 1 && directionZ == -1)
        {
            return oneThirtyFiveDegree.rotation;
        }
        else if (directionX == -1 && directionZ == -1)
        {
            return twoTwoFiveDegree.rotation;
        }

        else if (directionX != 0)
        {
            if (directionX == 1)
                return nintyDegree.rotation;

            else if (directionX == -1)
                return minNintyDegree.rotation;
            else
                return Quaternion.identity;
        }

        else if (directionZ != 0)
        {
            if (directionZ == 1)
                return Quaternion.identity;

            else if (directionZ == -1)
                return minOneEightyDegree.rotation;
            else
                return Quaternion.identity;
        }
        else
            return Quaternion.identity;

    }
}
