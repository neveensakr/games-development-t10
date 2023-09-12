using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBullet : Bullet
{
    [SerializeField] private float explosionRadius = 4f;
    [SerializeField] private int fireDamage = 50;
    
    public override void Damage(EnemyHealth enemyHealth)
    {
        ElementHealthBar elementHealthBar = enemyHealth.GetComponent<ElementHealthBar>();
        IncreaseElementBar(Element.Fire, enemyHealth);
        if (elementHealthBar.ActiveElement == Element.Fire && elementHealthBar.AtPeakTime)
        {
            GameManager.Instance.StartCoroutine(StartExplosion(elementHealthBar, enemyHealth));
        }
    }

    private IEnumerator StartExplosion(ElementHealthBar elementHealthBar, EnemyHealth enemyHealth)
    {
        GameObject fireEffect = enemyHealth.transform.GetChild(2).gameObject;
        for (int i = 0; i < elementHealthBar.timeAtMax; i++)
        {
            fireEffect.GetComponent<SpriteRenderer>().enabled = true;
            if (elementHealthBar != null) 
            { 
                elementHealthBar.Explode(explosionRadius, fireDamage);
                yield return new WaitForSeconds(1);
            }
            fireEffect.GetComponent<SpriteRenderer>().enabled = false;
        }
        
        yield break;
    }
}
