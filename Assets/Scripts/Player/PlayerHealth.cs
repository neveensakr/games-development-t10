﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] public float maxHealth = 100f; // The maximum health the player can have
    [SerializeField] private float healFraction = 0.1f; // Fraction of maxHealth to heal per interval
    [SerializeField] private float timeToStartHealing = 10f; // The time after taking damage to start healing
    [SerializeField] private float timeBetweenHealing = 2f; // The time between each health increase

    private float currentHealth; // The current health of the player
    private Coroutine healthIncreaseCoroutine; // Reference to the health increase coroutine
    private float lastDamageTime; // Variable to store the time of the last damage taken
    private bool isHealing; // Flag to check if the player is currently healing

    private void Start()
    {
        currentHealth = maxHealth; // Initialize current health to max health at the start
        lastDamageTime = Time.time; // Initialize the last damage time
        isHealing = false; // Initialize the isHealing flag to false
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
            lastDamageTime = Time.time; // Update the last damage time
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

    public float GetTimeToStartHealing()
    {
        return timeToStartHealing;
    }

    public float GetLastDamageTime()
    {
        return lastDamageTime;
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
            isHealing = false; // Set the isHealing flag to false when stopping healing
        }
    }

    public bool IsHealing()
    {
        return isHealing;
    }

    private IEnumerator HealthIncreaseCoroutine()
    {
        isHealing = true; // Set the isHealing flag to true when starting healing

        // Wait for the specified time before starting to heal again
        yield return new WaitForSeconds(timeToStartHealing);

        while (currentHealth < maxHealth)
        {
            yield return new WaitForSeconds(timeBetweenHealing);
            currentHealth += maxHealth * healFraction;
            currentHealth = Mathf.Clamp(currentHealth, 0f, maxHealth);
        }

        isHealing = false; // Set the isHealing flag to false when healing is complete
        healthIncreaseCoroutine = null;
    }
}