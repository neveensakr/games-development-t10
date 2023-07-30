using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthBar : MonoBehaviour
{
    private PlayerHealth playerHealth;
    private Slider healthSlider;

    private void Start()
    {
        playerHealth = GameManager.Player.GetComponent<PlayerHealth>();
        healthSlider = GetComponent<Slider>();
        healthSlider.maxValue = playerHealth.maxHealth;
    }

    private void Update()
    {
        float currentHealth = playerHealth.GetCurrentHealth();
        healthSlider.value = currentHealth;
    }
}


