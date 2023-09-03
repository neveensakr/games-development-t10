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
            StartCoroutine(StartExplosion(elementHealthBar));
        }
    }

    private IEnumerator StartExplosion(ElementHealthBar elementHealthBar)
    {
        for (int i = 0; i < elementHealthBar.timeAtMax; i++)
        {
            Explode(explosionRadius, fireDamage);
            yield return new WaitForSeconds(1);
        }
        
        yield break;
    }
}
