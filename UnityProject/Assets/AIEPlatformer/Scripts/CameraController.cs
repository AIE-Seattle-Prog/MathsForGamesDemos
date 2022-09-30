using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform followTarget;
    public Vector3 followOffset = new Vector3(0,1,-1);

    public float followOffsetLengthDelta = 0.0f;
    public float zoomSpeed = 1.5f;

    public float minDelta = .5f;
    public float maxDelta = 5.0f;

    public float yaw;
    public float pitch;

    private void Update()
    {
        yaw += Input.GetAxisRaw("Mouse X");
        pitch -= Input.GetAxisRaw("Mouse Y");

        followOffsetLengthDelta -= Input.mouseScrollDelta.y * zoomSpeed;
        followOffsetLengthDelta = Mathf.Clamp(followOffsetLengthDelta, minDelta, maxDelta);
    }

    void LateUpdate()
    {
        float offsetLength = followOffset.magnitude + followOffsetLengthDelta;
        Vector3 offset = followOffset.normalized * offsetLength;

        // rotate offset
        offset = Quaternion.AngleAxis(yaw, Vector3.up) * Quaternion.AngleAxis(pitch, Vector3.right) * offset;

        transform.position = followTarget.position + offset;
        transform.forward = followTarget.position - transform.position;
    }
}
