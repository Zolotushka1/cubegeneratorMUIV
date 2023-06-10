using UnityEngine;

public class MouseMove : MonoBehaviour
{
    [SerializeField] private Camera playerCamera;
    [SerializeField] private GameObject playerGameObject;
    [Header("Mouse settings")]
    [SerializeField] private float sensitivity = 5f;
    [SerializeField] private float SmoothTime = 0.1f;
    float xRot = 0;
    float xRotCurrent = 0;
    float yRot;
    float yRotCurrent;
    float currentVelosityX;
    float currentVelosityY;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        xRotCurrent = playerGameObject.transform.rotation.eulerAngles.y;
        yRotCurrent = -playerCamera.transform.localRotation.eulerAngles.x;
        if (yRotCurrent < -90)
        {
            yRotCurrent += 360;
            if (yRotCurrent > 90)
            {
                yRotCurrent = 0;
            }
        }
        xRot = xRotCurrent;
        yRot = yRotCurrent;
    }

    void Update()
    {
        xRot += Input.GetAxis("Mouse X") * sensitivity;
        yRot += Input.GetAxis("Mouse Y") * sensitivity;
        yRot = Mathf.Clamp(yRot, -90, 90);

        xRotCurrent = Mathf.SmoothDamp(xRotCurrent, xRot, ref currentVelosityX, SmoothTime);
        yRotCurrent = Mathf.SmoothDamp(yRotCurrent, yRot, ref currentVelosityY, SmoothTime);

        playerCamera.transform.localRotation = Quaternion.Euler(-yRotCurrent, 0f, 0f);
        playerGameObject.transform.rotation = Quaternion.Euler(0f, xRotCurrent, 0f);
    }
}
