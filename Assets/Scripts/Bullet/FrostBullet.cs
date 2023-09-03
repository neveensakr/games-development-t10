using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrostBullet : Bullet
{
    public override void Damage(EnemyHealth enemyHealth)
    {
        if (IncreaseElementBar(Element.Frost, enemyHealth))
        {
            Debug.Log("FROST DAMAGE");
        }
    }

}
