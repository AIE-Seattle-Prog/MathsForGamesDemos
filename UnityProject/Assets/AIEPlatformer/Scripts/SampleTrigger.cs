using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SampleTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Entered Trigger:" + other.name);
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Exited Trigger:" + other.name);
    }
}
