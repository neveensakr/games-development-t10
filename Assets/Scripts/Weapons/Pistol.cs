using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : Weapon
{
    public override void Fire(GameObject bulletPrefab)
    {
        Debug.Log("Pistol Firing!");
        Bullet bullet = Instantiate(bulletPrefab, FirePoint.position, FirePoint.rotation).GetComponent<Bullet>();
        bullet.owner = Characters.Player;
        bullet.bulletDamage = Damage;
        AudioManager.Instance.PlayerShootSound(); // Play the shooting sound
    }
}
