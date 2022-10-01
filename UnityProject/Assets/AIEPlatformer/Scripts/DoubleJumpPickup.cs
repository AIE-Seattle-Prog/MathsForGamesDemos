using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleJumpPickup : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // is this a player?
        if(other.TryGetComponent<PlayerMotor>(out PlayerMotor player))
        {
            // reset the player's air jumps
            player.ResetAirJumps();

            // our work is here, time to destroy ourselves
            Destroy(gameObject);
        }
    }
}
