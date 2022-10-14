using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemoWorldToScreen : MonoBehaviour
{
    // Camera used by the player to view the game world
    public Camera playerCamera;

    // Transform of the object it's tracking
    public Transform trackedObject;

    // RectTRansform of the UI object we're moving
    public RectTransform iconTransform;

    void Update()
    {
        Vector3 screenPos = playerCamera.WorldToScreenPoint(trackedObject.position);
        iconTransform.anchoredPosition = screenPos;
    }
}
