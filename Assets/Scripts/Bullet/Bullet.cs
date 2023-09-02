using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Characters
{
    Player,
    Enemy
}

public abstract class Bullet : MonoBehaviour
{
    public Characters owner;
    private Rigidbody2D rb;
    public int bulletDamage = 10; // Set the damage amount in the Inspector

    public abstract void Damage(EnemyHealth enemyHealth);

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(transform.up * 20f, ForceMode2D.Impulse);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        switch (owner)
        {
            case Characters.Enemy:
            {
                // Check if the collided object has the PlayerHealth component
                PlayerHealth playerHealth = collider.gameObject.GetComponent<PlayerHealth>();
                if (playerHealth != null && !collider.isTrigger)
                {
                        // If the collided object is the player, deal damage to the player
                        playerHealth.TakeDamage(bulletDamage);      
                }
                break;
            }
            case Characters.Player:
            {
                Debug.Log(collider);
                // Check if the collided object has the EnemyHealth component
                EnemyHealth enemyHealth = collider.gameObject.GetComponent<EnemyHealth>();
                if (enemyHealth != null && !collider.isTrigger)
                {
                        // If the collided object is an enemy, deal damage to the enemy
                        enemyHealth.TakeDamage(bulletDamage);
                        Damage(enemyHealth);
                }
                break;
            }
        }
        // If we hit a solid object that is not the player or enemy, destroy the bullet
        if (!collider.isTrigger) Destroy(gameObject);
    }
}
