using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SampleCollision : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision Enter:" + collision.gameObject.name);
    }

    private void OnCollisionExit(Collision collision)
    {
        Debug.Log("Collision Exit:" + collision.gameObject.name);
    }
}
