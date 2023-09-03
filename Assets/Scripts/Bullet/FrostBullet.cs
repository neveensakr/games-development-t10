using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrostBullet : Bullet
{
    [SerializeField] private float amount = 0.5f;
    
    public override void Damage(EnemyHealth enemyHealth)
    {

        ElementHealthBar elementHealthBar = enemyHealth.GetComponent<ElementHealthBar>();
        if (IncreaseElementBar(Element.Frost, enemyHealth))
        {
            Debug.Log("FROST DAMAGE");

            enemyHealth.GetComponent<EnemyController>().DecreaseSpeed(amount);
            
        }
        if (elementHealthBar.ActiveElement == Element.Frost && elementHealthBar.AtPeakTime)
        {
            enemyHealth.GetComponent<EnemyController>().moveSpeed = 0f;
        }
    }

}
