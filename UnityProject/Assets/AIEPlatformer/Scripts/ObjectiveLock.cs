using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectiveLock : MonoBehaviour
{
    public ObjectiveKey key;

    public void Unlock(ObjectiveKey key)
    {
        // TODO: add sfx and things
        gameObject.SetActive(false);
    }
}
