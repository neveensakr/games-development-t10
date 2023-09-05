using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : Weapon
{
    public override void Fire(GameObject bulletPrefab)
    {
        Debug.Log("Pistol Firing!");
        for (var i = 1; i < this.gameObject.transform.childCount; i++) {
            this.gameObject.transform.GetChild(i).GetComponent<Flare>().flareActive = true;
            StartCoroutine(this.gameObject.transform.GetChild(i).GetComponent<Flare>().HideFlare());
        }
        Bullet bullet = Instantiate(bulletPrefab, FirePoint.position, FirePoint.rotation).GetComponent<Bullet>();
        bullet.owner = Characters.Player;
        bullet.bulletDamage = Damage;
        AudioManager.Instance.PlayerShootSound(); // Play the shooting sound
    }
}
