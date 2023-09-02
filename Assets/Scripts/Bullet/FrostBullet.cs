using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrostBullet : Bullet
{
    public override void Damage(EnemyHealth enemyHealth)
    {
        Debug.Log("Frost Bullet");
    }

}
