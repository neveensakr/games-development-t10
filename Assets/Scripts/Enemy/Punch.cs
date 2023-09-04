using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Punch : MonoBehaviour
{
    public int punchDamage = 10; // Set the damage amount in the Inspector

    private void OnTriggerEnter2D(Collider2D collider)
    {
        // Check if the collided object has the PlayerHealth component
        PlayerHealth playerHealth = collider.gameObject.GetComponent<PlayerHealth>();
        if (playerHealth != null && !collider.isTrigger)
        {
            // If the collided object is the player, deal damage to the player
            playerHealth.TakeDamage(punchDamage);
        }
    }
}
