using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectiveKey : MonoBehaviour
{
    private PlayerMotor playerHolder;

    public float orbitSpeed = 180.0f;
    public float orbitRadius = 2.0f;

    public float bounceSpeed = 2.0f;
    public float bounceHeight = 0.1f;

    // get inserted into the lock

    private void Update()
    {
        if(playerHolder != null)
        {
            Vector3 offset = Vector3.zero;

            // orbit
            offset.x = Mathf.Cos(Mathf.Deg2Rad * orbitSpeed * Time.time);
            offset.z = Mathf.Sin(Mathf.Deg2Rad * orbitSpeed * Time.time);
            offset *= orbitRadius;

            // bounce
            offset.y = Mathf.Sin(bounceSpeed * Time.time) * bounceHeight;

            transform.position = playerHolder.transform.position + offset;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // get picked up by the player
        if (playerHolder == null)
        {
            if (other.TryGetComponent<PlayerMotor>(out PlayerMotor player))
            {
                playerHolder = player;
            }
        }
        else if (other.TryGetComponent<ObjectiveLock>(out ObjectiveLock objective))
        {
            // are we the right key for this lock?
            if(objective.key == this)
            {
                objective.Unlock(this);
            }
        }
    }
}
