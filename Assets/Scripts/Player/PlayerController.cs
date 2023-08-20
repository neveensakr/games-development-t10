using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject bulletPrefab;
    public GameObject shotFlarePrefab;
    public Transform firePoint;
    private PlayerHealth playerHealth;
    public int playerBulletDamage = 10; // Set the damage amount for player's bullet in the Inspector

    private void Start()
    {
        playerHealth = GetComponent<PlayerHealth>();
    }

    private void Update()
    {
        if (InputManager.InputActivated && playerHealth.GetCurrentHealth() > 0f)
        {
            if (Input.GetMouseButtonDown(0))
            {
                // Set the bullet damage directly before firing
                Bullet bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation).GetComponent<Bullet>();
                bullet.owner = Characters.Player;
                bullet.bulletDamage = playerBulletDamage;
                Flare flare = Instantiate(shotFlarePrefab, firePoint.position, firePoint.rotation).GetComponent<Flare>();
            }
        }
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
