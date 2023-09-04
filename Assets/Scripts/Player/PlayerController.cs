using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject bulletPrefab;
    public GameObject flare;
    public Transform firePoint;
    private PlayerHealth playerHealth;

    private void Start()
    {
        playerHealth = GetComponent<PlayerHealth>();
    }

    // Call this method when the player is hit by an bullet grenade
    public void OnHitByEnemyBullet()
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
