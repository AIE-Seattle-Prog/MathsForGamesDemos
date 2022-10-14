using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCameraController : MonoBehaviour
{
    public Transform trackedObject;

    public float distance = 5.0f;

    // the rate at which we rotate the camera - MOUSE SENSITIVITY
    public float rotateSpeed = 270.0f;

    public float maxPitch = 89.0f;

    // the actual amount of rotation on the Y-axis
    private float controlYaw;
    private float controlPitch;

    private void OnEnable()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void LateUpdate()
    {
        controlYaw += Input.GetAxisRaw("Mouse X") * rotateSpeed * Time.deltaTime;
        controlPitch += -Input.GetAxisRaw("Mouse Y") * rotateSpeed * Time.deltaTime;
        controlPitch = Mathf.Clamp(controlPitch, -maxPitch, +maxPitch);

        Quaternion controlRot = Quaternion.AngleAxis(controlYaw, Vector3.up);
        controlRot *= Quaternion.AngleAxis(controlPitch, Vector3.right);
        
        Vector3 finalOffset = controlRot * new Vector3(0, 0, -distance);

        // where is the camera?
        transform.position = trackedObject.position + finalOffset;

        // which way is the camera facing?
        transform.forward = (trackedObject.position - transform.position).normalized;
    }
}
