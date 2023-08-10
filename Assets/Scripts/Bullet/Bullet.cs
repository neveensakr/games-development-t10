using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody2D rb;
    public int bulletDamage = 10; // Set the damage amount in the Inspector

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(transform.up * 20f, ForceMode2D.Impulse);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the collided object has the PlayerHealth component
        PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();
        if (playerHealth != null)
        {
            // If the collided object is the player, deal damage to the player
            playerHealth.TakeDamage(bulletDamage);
        }

        // Check if the collided object has the EnemyHealth component
        EnemyHealth enemyHealth = collision.gameObject.GetComponent<EnemyHealth>();
        if (enemyHealth != null)
        {
            // If the collided object is an enemy, deal damage to the enemy
            enemyHealth.TakeDamage(bulletDamage);
            // Debug.LogError("ENEMY DAMAGE");
        }
         // Destroy the grenade object after it collides with something
        Destroy(gameObject);
    }
}



