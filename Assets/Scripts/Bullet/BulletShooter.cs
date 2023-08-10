using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletShooter : MonoBehaviour
{
    public GameObject bullet;
    public Transform firePoint;
    public int bulletDamage = 10; // Set the damage amount in the Inspector

    public void Fire()
    {
        // Create a new grenade GameObject at the firePoint position and rotation
        GameObject projectile = Instantiate(bullet, firePoint.position, firePoint.rotation);
    }  
}
