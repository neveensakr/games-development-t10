using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletShooter : MonoBehaviour
{
    public GameObject bullet;
    public Transform from;

    public void Fire()
    {
        GameObject projectile = Instantiate(bullet, from.position, from.rotation);
    }
}
