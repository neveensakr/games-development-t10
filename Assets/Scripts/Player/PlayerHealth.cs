using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] public float maxHealth = 100f; // The maximum health the player can have
    [SerializeField] private float healFraction = 0.01f; // Fraction of maxHealth to heal per interval
    [SerializeField] private float timeToStartHealing = 20f; // The time after taking damage to start healing
    [SerializeField] private float timeBetweenHealing = 2f; // The time between each health increase

    private float currentHealth; // The current health of the player
    private Coroutine healthIncreaseCoroutine; // Reference to the health increase coroutine

    private void Start()
    {
        currentHealth = maxHealth; // Initialize current health to max health at the start
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage; // Reduce current health by the damage amount
        if (currentHealth <= 0)
        {
            Die();
        }
        else
        {
            StartHealing(); // Start healing if the player is still alive
        }
    }

    private void Die()
    {
        // Perform any death animations/effects here
        Destroy(gameObject);
    }

    public float GetCurrentHealth()
    {
        return currentHealth;
    }

    public float GetMaxHealth()
    {
        return maxHealth;
    }

    public void StartHealing()
    {
        if (healthIncreaseCoroutine == null)
        {
            healthIncreaseCoroutine = StartCoroutine(HealthIncreaseCoroutine());
        }
    }

    public void StopHealing()
    {
        if (healthIncreaseCoroutine != null)
        {
            StopCoroutine(healthIncreaseCoroutine);
            healthIncreaseCoroutine = null;
        }
    }

    private IEnumerator HealthIncreaseCoroutine()
    {
        yield return new WaitForSeconds(timeToStartHealing);

        while (currentHealth < maxHealth)
        {
            yield return new WaitForSeconds(timeBetweenHealing);
            currentHealth += maxHealth * healFraction;
            currentHealth = Mathf.Clamp(currentHealth, 0f, maxHealth);
        }

        healthIncreaseCoroutine = null;
    }
}

