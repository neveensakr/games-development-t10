using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private int maxHealth = 30;
    private int currentHealth;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        // Reduce the current health of the enemy by the specified damage amount
        currentHealth -= damage;
        if (currentHealth <= 0)  // Check if the current health is less than or equal to 0
        {
            Die(); // If the enemy's health is depleted, call the Die method to handle death logic
        }
    }

    private void Die()
    {
        // Perform any death animations/effects here
        Destroy(gameObject);
    }
}

