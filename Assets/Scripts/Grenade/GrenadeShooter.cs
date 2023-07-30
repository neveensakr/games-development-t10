using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeShooter : MonoBehaviour
{
    public GameObject grenade;
    public Transform firePoint;
    public int grenadeDamage = 1; // Set the damage amount in the Inspector

    public void Fire()
    {
        // Create a new grenade GameObject at the firePoint position and rotation
        GameObject projectile = Instantiate(grenade, firePoint.position, firePoint.rotation);
    }
}


