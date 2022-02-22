using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        var playerMovement = other.GetComponent<PlayerMovement>();
        if (playerMovement == null) return;

        print("Dead");

        playerMovement.enabled = false;
    }
}
