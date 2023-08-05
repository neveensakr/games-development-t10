using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    public float throwForce = 10f;
    public float damageRadius = 3f;

    void Start()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.AddForce(transform.up * throwForce, ForceMode2D.Impulse);
        StartCoroutine(StartGrenade());
    }
    
    private IEnumerator StartGrenade()
    {
        yield return new WaitForSecondsRealtime(3f);
        Debug.Log("EXPLODING!!!");
        // Trigger Partcle Effect

        Collider2D[] objectsAround = Physics2D.OverlapCircleAll(transform.position, damageRadius);
        foreach (Collider2D obj in objectsAround)
        {
            EnemyHealth enemyHealth = obj.GetComponent<EnemyHealth>();
            // IsTrigger check as we only want to hit enemies the player can bump into
            if (!obj.isTrigger && enemyHealth != null)
            {
                enemyHealth.TakeDamage(10);
            }
        }

        Destroy(gameObject);
    }
    
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(this.transform.position, damageRadius);
    }
}
