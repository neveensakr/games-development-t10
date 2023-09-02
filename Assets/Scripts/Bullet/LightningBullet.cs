using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningBullet : Bullet
{
    public override void Damage(EnemyHealth enemyHealth)
    {
        Debug.Log("Lightning Bullet");
    }

}
