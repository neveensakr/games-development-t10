using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthBar : MonoBehaviour
{
    [SerializeField] private PlayerHealth playerHealth;
    private Slider healthSlider;

    private void Start()
    {
        healthSlider = GetComponent<Slider>();
        healthSlider.maxValue = playerHealth.maxHealth;
    }

    private void Update()
    {
        float currentHealth = playerHealth.GetCurrentHealth();
        healthSlider.value = currentHealth;
    }
}


