using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    float MouseSensivity = 100;
    Transform playerBody;
    float xRotation;
    void Start()
    {
        playerBody = transform.parent;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        CameraRotation();
    }
    void CameraRotation()
    {
        float mouseX = Input.GetAxis("Mouse X") * MouseSensivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * MouseSensivity * Time.deltaTime;
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90, 80);

        transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
        playerBody.Rotate(Vector3.up * mouseX);
    }
}
