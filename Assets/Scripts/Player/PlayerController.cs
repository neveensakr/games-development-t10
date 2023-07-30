using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private GrenadeShooter shooter;
    private PlayerHealth playerHealth;

    void Start()
    {
        shooter = GetComponent<GrenadeShooter>();
        playerHealth = GetComponent<PlayerHealth>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            shooter.Fire();
        }
    }

    // Call this method when the player is hit by an enemy grenade
    public void OnHitByEnemyGrenade()
    {
        playerHealth.StopHealing();
    }
}







