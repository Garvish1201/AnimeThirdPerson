using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    [Header (" Elements ")]
    [SerializeField] private InputManager inputManager;
    [SerializeField] private Animator playerAnimator;
    [SerializeField] private Transform cameraTransform;

    [Header(" Settings ")]
    [SerializeField] private Vector2 minMaxTargetSpeed;
    [SerializeField] private float rotationSmoothness;

    [SerializeField] private Quaternion offsetRotation;

    float targetSpeed;
    float speed;

    private void Update()
    {
        if (inputManager.GetForwardMovementInput() != 0)
        {
            speed = Mathf.Abs(inputManager.GetForwardMovementInput());
        }
        else if (inputManager.GetSideMovementInput() != 0)
        {
            speed = Mathf.Abs(inputManager.GetSideMovementInput());
            
        }
        else
        {
            speed = 0;
        }

        targetSpeed = Mathf.MoveTowards(targetSpeed, speed, AdjusedtPickUpSpeed() * Time.deltaTime);
        playerAnimator.SetFloat("Walk", targetSpeed);

        RotatePlayer();
    }

    private float AdjusedtPickUpSpeed()
    {
        if (inputManager.GetForwardMovementInput() < 1)
            return minMaxTargetSpeed.x;
        else
            return minMaxTargetSpeed.y;
    }

    private void RotatePlayer()
    {
        if (speed != 0)
        {
            transform.rotation = Quaternion.Lerp
            (
                transform.rotation, 
                cameraTransform.rotation * inputManager.GetOffsetRotation(),
                rotationSmoothness * Time.deltaTime
            );
        }
    }
}
