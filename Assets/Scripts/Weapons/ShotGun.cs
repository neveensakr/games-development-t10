using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotGun : Weapon
{
    public override void Fire(GameObject bulletPrefab)
    {
        Debug.Log("Shotgun Firing!");
    }
}
