using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public enum RotationAxes
    {
        MouseXAndY = 0,
        MouseX = 1,
        MouseY = 2
    }

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    [SerializeField]
    private RotationAxes axes = RotationAxes.MouseXAndY;

    [SerializeField]
    public static float horizontalSensitivity = 9.0f;

    [SerializeField]
    public static float verticalSensitivity = 9.0f;
    [SerializeField]
    private float minimumVertical = -45.0f;
    [SerializeField]
    private float maximumVertical = 45.0f;

    private float verticalRotation = 0.0f;

    void Update()
    {
        if(axes == RotationAxes.MouseX)
        {
            transform.Rotate(0, Input.GetAxis("Mouse X") * horizontalSensitivity, 0);
        }
        else if(axes == RotationAxes.MouseY)
        {
            verticalRotation -= Input.GetAxis("Mouse Y") * verticalSensitivity;
            verticalRotation = Mathf.Clamp(verticalRotation, minimumVertical, maximumVertical);

            float horizontalRotation = transform.localEulerAngles.y;

            transform.localEulerAngles = new Vector3(verticalRotation, horizontalRotation, 0);
        }
        else
        {
            verticalRotation -= Input.GetAxis("Mouse Y") * verticalSensitivity;
            verticalRotation = Mathf.Clamp(verticalRotation, minimumVertical, maximumVertical);

            float delta = Input.GetAxis("Mouse X") * horizontalSensitivity;
            float horizontalRotation = transform.localEulerAngles.y + delta;

            transform.localEulerAngles = new Vector3(verticalRotation, horizontalRotation, 0);
        }
    }
}