using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    public float throwForce = 10f;
    public float damageRadius = 3f;
    public int grenadeDamage = 10;
    public Characters owner;
    public GameObject explosionEffect; // The effect spawns when the enemy dies

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
            // EnemyHealth enemyHealth = obj.GetComponent<EnemyHealth>();
            // // IsTrigger check as we only want to hit enemies the player can bump into
            // if (!obj.isTrigger && enemyHealth != null)
            // {
            //     enemyHealth.TakeDamage(10);
            // }

            switch (owner)
            {
                case Characters.Enemy:
                {
                    // Check if the collided object has the PlayerHealth component
                    PlayerHealth playerHealth = obj.GetComponent<PlayerHealth>();
                    if (!obj.isTrigger && playerHealth != null)
                    {
                        // If the collided object is the player, deal damage to the player
                        playerHealth.TakeDamage(grenadeDamage);
                    }
                    break;
                }
                case Characters.Player:
                {
                    EnemyHealth enemyHealth = obj.GetComponent<EnemyHealth>();
                    // IsTrigger check as we only want to hit enemies the player can bump into
                    if (!obj.isTrigger && enemyHealth != null)
                    {
                        enemyHealth.TakeDamage(grenadeDamage);
                    }
                    break;
                }
            }
        }
        Instantiate(explosionEffect, transform.position, transform.rotation);
        Destroy(gameObject);
    }
    
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(this.transform.position, damageRadius);
    }
}
