using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float MouseSensititvity = 100f;

    public Transform PlayerBody;

    float xRotation = 0f;
    
    void Start()
    {
        Cursor.lockState = CursorLockMode.Confined;
    }

    void Update()
    {
        HandleMouseCamera();
    }

    internal void HandleMouseCamera()
    {
        float mouseX = Input.GetAxis("Mouse X") * MouseSensititvity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * MouseSensititvity * Time.deltaTime;
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0, 0);

        PlayerBody.Rotate(Vector3.up * mouseX);
    }
}
