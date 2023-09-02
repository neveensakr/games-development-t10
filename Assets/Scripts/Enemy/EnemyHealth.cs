using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class DeathEvent : UnityEvent<GameObject> { }

public class EnemyHealth : MonoBehaviour
{
    public DeathEvent OnDeath = new DeathEvent();
    
    [SerializeField] public float maxHealth = 3f; // The maximum health the enemy can have
    public GameObject deathEffect; // The effect spawns when the enemy dies
    public GameObject hitEffect; // The effect spawns when the enemy has gotten hit
    private float currentHealth; // The current health of the enemy
   

    private void Start()
    {
      
        currentHealth = maxHealth; // Initialize current health to max health at the start
        OnDeath.AddListener(GameManager.Instance.CheckIfWon);
    }


    public void TakeDamage(int damage)
    {
        currentHealth -= damage; // Reduce current health by the damage amount
        Instantiate(hitEffect, transform.position, transform.rotation);
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        AudioManager.Instance.EnemyDefeatSound(); // Play the enemy defeat sound
        // Perform any death animations/effects here
        Instantiate(deathEffect, transform.position, transform.rotation);
        OnDeath.Invoke(gameObject);
        Destroy(gameObject);
    }
}
