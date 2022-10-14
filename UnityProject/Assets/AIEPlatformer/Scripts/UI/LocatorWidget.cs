using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LocatorWidget : MonoBehaviour
{
    // The object that we need to locate
    public Transform trackedObject;

    // The UI Image used to display the location
    public Image locatorIcon;

    private RectTransform myRectTransform;

    private Camera trackerCamera;

    private void Start()
    {
        myRectTransform = GetComponent<RectTransform>();
        trackerCamera = Camera.main;
    }

    private void LateUpdate()
    {
        Vector3 iconScreenPos = trackerCamera.WorldToScreenPoint(trackedObject.position);
        // TODO: double check if this is the correct dimensions
        iconScreenPos.x = Mathf.Clamp(iconScreenPos.x, 0, Screen.width);
        iconScreenPos.y = Mathf.Clamp(iconScreenPos.y, 0, Screen.height);
        myRectTransform.anchoredPosition = iconScreenPos;
    }
}
