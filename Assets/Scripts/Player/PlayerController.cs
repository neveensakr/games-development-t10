// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class PlayerController : MonoBehaviour
// {
//     private GrenadeShooter shooter;
//     private PlayerHealth playerHealth;

//     void Start()
//     {
//         shooter = GetComponent<GrenadeShooter>();
//         playerHealth = GetComponent<PlayerHealth>();
//     }

//     void Update()
//     {
//         if (InputManager.InputActivated && playerHealth.GetCurrentHealth() > 0f)
//         {
//             if (Input.GetMouseButtonDown(0))
//             {
//                 shooter.Fire();
//             }
//         }
//     }

//     // Call this method when the player is hit by an enemy grenade
//     public void OnHitByEnemyGrenade()
//     {
//         playerHealth.StopHealing();
//     }
// }

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private BulletShooter shooter;
    private PlayerHealth playerHealth;
    public int playerGrenadeDamage = 10; // Set the damage amount for player's grenade in the Inspector

    private void Start()
    {
        shooter = GetComponent<BulletShooter>();
        playerHealth = GetComponent<PlayerHealth>();
    }

    private void Update()
    {
        if (InputManager.InputActivated && playerHealth.GetCurrentHealth() > 0f)
        {
            if (Input.GetMouseButtonDown(0))
            {
                // Set the grenade damage directly before firing
                shooter.grenadeDamage = playerGrenadeDamage;
                shooter.Fire();
            }
        }
    }

    // Call this method when the player is hit by an enemy grenade
    public void OnHitByEnemyGrenade()
    {
        playerHealth.StopHealing();
    }

    private void FixedUpdate()
    {
        // Check if the player is not taking damage for the specified time to start healing
        if (Time.time - playerHealth.GetLastDamageTime() >= playerHealth.GetTimeToStartHealing())
        {
            // Start healing if the player is not taking damage and not already healing
            if (playerHealth.GetCurrentHealth() < playerHealth.GetMaxHealth() && playerHealth.IsHealing() == false)
            {
                Debug.Log("Started healing coroutine");
                playerHealth.StartHealing();
            }
        }
        else
        {
            // If the player is taking damage or has not waited for the specified time, stop healing
            if (playerHealth.IsHealing())
            {
                Debug.Log("Stopped healing coroutine");
                playerHealth.StopHealing();
            }
        }
    }
}
