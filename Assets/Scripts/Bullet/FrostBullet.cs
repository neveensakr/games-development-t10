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
            
            GameObject frostEffect = enemyHealth.transform.GetChild(3).gameObject;
            frostEffect.GetComponent<SpriteRenderer>().enabled = true;
            if (enemyHealth.GetComponent<EnemyController>()) {
                enemyHealth.GetComponent<EnemyController>().moveSpeed = 0f;
                enemyHealth.GetComponent<EnemyController>().isShooting = false;
                frostEffect.GetComponent<Animator>().Play("Effect (Frost) (Gunslinger)", -1, 0f);
                frostEffect.GetComponent<Animator>().Play("Effect (Frost) (Spike)", -1, 0f);
            }
            else if (enemyHealth.GetComponent<EnemyFourArms>()) {
                enemyHealth.GetComponent<EnemyFourArms>().moveSpeed = 0f;
                frostEffect.GetComponent<Animator>().Play("Effect (Frost) (FourArms)", -1, 0f);
            }
            
        }
        
    }

}
