using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Rocket : MonoBehaviour
{
    public Characters owner;
    public float explosionRadius = 5f; // Set the explosion radius in the Inspector
    public int rocketDamage = 20; // Set the damage amount in the Inspector
    public GameObject explosionEffect; // Assign the explosion effect prefab in the Inspector

    private void Start()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.AddForce(transform.up * 10f, ForceMode2D.Impulse);
    }

    private void Explode(Vector2 center)
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(center, explosionRadius);
        foreach (Collider2D collider in colliders)
        {
            if (owner == Characters.Enemy)
            {
                PlayerHealth playerHealth = collider.gameObject.GetComponent<PlayerHealth>();
                if (playerHealth != null)
                {
                    playerHealth.TakeDamage(rocketDamage);
                }
            }
            else if (owner == Characters.Player)
            {
                EnemyHealth enemyHealth = collider.gameObject.GetComponent<EnemyHealth>();
                if (enemyHealth != null)
                {
                    enemyHealth.TakeDamage(rocketDamage);
                }
            }
        }

        // Instantiate explosion effect
        if (explosionEffect != null)
        {
            Instantiate(explosionEffect, transform.position, Quaternion.identity);
        }

        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        

        if (explosionRadius > 0)
        {
            Explode(transform.position);
        }
        else
        {
            switch (owner)
            {
                case Characters.Enemy:
                    {
                        PlayerHealth playerHealth = collider.gameObject.GetComponent<PlayerHealth>();
                        if (playerHealth != null)
                        {
                            playerHealth.TakeDamage(rocketDamage);
                        }
                        break;
                    }
                case Characters.Player:
                    {
                        EnemyHealth enemyHealth = collider.gameObject.GetComponent<EnemyHealth>();
                        if (enemyHealth != null)
                        {
                            enemyHealth.TakeDamage(rocketDamage);
                        }
                        break;
                    }
            }
            if (!collider.isTrigger) Destroy(gameObject);
        }
    }
}
