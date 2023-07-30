using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private BulletShooter shooter;
    private PlayerHealth playerHealth;

    void Start()
    {
        shooter = GetComponent<BulletShooter>();
        playerHealth = GetComponent<PlayerHealth>();
    }

    void Update()
    {
        if (InputManager.InputActivated)
        {
            if (Input.GetMouseButtonDown(0))
            {
                shooter.Fire();
            }
        }
    }

    // Call this method when the player is hit by an enemy grenade
    public void OnHitByEnemyGrenade()
    {
        playerHealth.StopHealing();
    }
}







