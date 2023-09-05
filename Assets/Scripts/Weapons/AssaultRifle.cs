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
            AudioManager.Instance.PlayerShootSound(); // Play the shooting sound
            nextFireTime = Time.time + fireRate;
            for (var i = 1; i < this.gameObject.transform.childCount; i++) {
                this.gameObject.transform.GetChild(i).GetComponent<Flare>().flareActive = true;
            }
            
        }
        for (var i = 1; i < this.gameObject.transform.childCount; i++) {
            StartCoroutine(this.gameObject.transform.GetChild(i).GetComponent<Flare>().HideFlare());
        }
    }
}
