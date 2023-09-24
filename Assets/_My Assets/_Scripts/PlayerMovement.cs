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

    float targetSpeed;
    float speed;

    private void Update()
    {
        speed = inputManager.GetForwarMovementInput();

        targetSpeed = Mathf.MoveTowards(targetSpeed, speed, AdjusedtPickUpSpeed() * Time.deltaTime);
        playerAnimator.SetFloat("Walk", targetSpeed);

        RotatePlayer();
    }

    private float AdjusedtPickUpSpeed()
    {
        if (inputManager.GetForwarMovementInput() < 1)
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
                cameraTransform.rotation,
                AdjusedtPickUpSpeed() * rotationSmoothness * Time.deltaTime
            );
        }
    }
}
