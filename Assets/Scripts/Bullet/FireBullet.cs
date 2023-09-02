using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBullet : Bullet
{



    public override void Damage(EnemyHealth enemyHealth)
    {
        ElementHealthBar elementHealthBar = enemyHealth.GetComponent<ElementHealthBar>();
        if (elementHealthBar.ActiveElement != Element.Fire || elementHealthBar.ActiveElement != Element.none) return;

        elementHealthBar.ActiveElement = Element.Fire;
        elementHealthBar.elementTime += 2;
    }

}
