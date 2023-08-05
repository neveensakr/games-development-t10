using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] public float maxHealth = 3f; // The maximum health the enemy can have
    private float currentHealth; // The current health of the enemy

    private void Start()
    {
        currentHealth = maxHealth; // Initialize current health to max health at the start
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage; // Reduce current health by the damage amount
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        // Perform any death animations/effects here
        Destroy(gameObject);
    }

    // Other methods and code...
}


