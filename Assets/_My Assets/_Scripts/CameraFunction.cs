using UnityEngine;

public class CameraFunction : MonoBehaviour
{
    [Header (" Elements ")]
    [SerializeField] private InputManager inputManager;
    [SerializeField] private Transform playerTransform;

    [Header (" Settings ")]
    [SerializeField] private float smoothnessValue = 1;

    float yRotation = 0;

    private void LateUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, playerTransform.position, smoothnessValue * Time.deltaTime);
        yRotation += inputManager.MoveXMovement();
        transform.rotation = Quaternion.Euler(0, yRotation, 0);
    }
}
