using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssaultRifle : Weapon
{
    [SerializeField] GameObject bulletPrefab;

    [SerializeField] private float fireRate = 0.1f;
    private float nextFireTime = 0f;

    public override void Fire(GameObject bulletPrefab)
    {
        while (IsActive && Time.time > nextFireTime)
        {
            Bullet bullet = Instantiate(bulletPrefab, FirePoint.position, FirePoint.rotation).GetComponent<Bullet>();
            bullet.owner = Characters.Player;
            bullet.bulletDamage = Damage;
            nextFireTime = Time.time + fireRate;
        }
    }
}
