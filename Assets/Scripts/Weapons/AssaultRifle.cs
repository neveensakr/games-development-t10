using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssaultRifle : Weapon
{
    [SerializeField] GameObject bulletPrefab;

    [SerializeField] private float fireRate = 0.1f;
    private float nextFireTime = 0f;

    private void Update()
    {
        if (IsActive && Time.time > nextFireTime && Input.GetButton("Fire1"))
        {
            Fire(bulletPrefab);
            nextFireTime = Time.time + fireRate;
        }
    }

    public override void Fire(GameObject bulletPrefab)
    {
        Bullet bullet = Instantiate(bulletPrefab, FirePoint.position, FirePoint.rotation).GetComponent<Bullet>();
        bullet.owner = Characters.Player;
        bullet.bulletDamage = Damage;
    }
}
