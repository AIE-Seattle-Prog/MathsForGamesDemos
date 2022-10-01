using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform followTarget;

    public Vector3 followOffset = new Vector3(0, 4, -6);

    private void LateUpdate()
    {
        transform.position = followTarget.position + followOffset;
    }
}
