using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeShooter : MonoBehaviour
{

    public GameObject grenade;

    public Transform from;

    public float FireForce;

    public void Fire()
    {
        GameObject projectile = Instantiate(grenade, from.position, from.rotation);

    }
}
