﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningBullet : Bullet
{
    [SerializeField] private float explosionRadius = 4f;
    [SerializeField] private int lightningDamage = 30;
    public GameObject lightningEffect; // The lightning prefab

    public override void Damage(EnemyHealth enemyHealth)
    {
        ElementHealthBar elementHealthBar = enemyHealth.GetComponent<ElementHealthBar>();
        IncreaseElementBar(Element.Lightning, enemyHealth);
        if (elementHealthBar.ActiveElement == Element.Lightning && elementHealthBar.AtPeakTime)
        {
            elementHealthBar.Explode(explosionRadius, lightningDamage);
            Instantiate(lightningEffect, transform.position, transform.rotation);
        }
    }
}
