using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float minDistanceToPlayer = 1.5f; // Minimum distance to maintain from the player

    public GameObject bulletPrefab; // The bullet prefab
    public Transform firePoint; // The point from where bullets are fired
    public float fireRate = 2f; // Fire rate in seconds

    private Transform target;
    private Vector2 moveDirection;
    private Rigidbody2D rb;
    private EnemyHealth enemyHealth;
    private bool isShooting = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        enemyHealth = GetComponent<EnemyHealth>(); // Assign the EnemyHealth component
    }

    private void Update()
    {
        if (target && !isShooting)
        {
            StartCoroutine(Shoot());
        }
    }

    private void FixedUpdate()
    {
        if (target)
        {
            // Calculate the distance to the player
            float distance = Vector2.Distance(transform.position, target.position);
            // Check if the enemy is outside the detection range
            if (distance > minDistanceToPlayer)
            {
                moveDirection = (target.position - transform.position).normalized;
                float angle = Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg;
                rb.rotation = angle - 90f;
                rb.velocity = moveDirection * moveSpeed; // Move towards the player
            }
            else
            {
                rb.velocity = Vector2.zero; // Stop moving if within the detection range
            }
            
        }
        else
        {
            rb.velocity = Vector2.zero; // Stop moving if there is no target
        }
    }

    // Call this method when the enemy needs to deal damage
    public void DealDamage(int damage)
    {
        enemyHealth.TakeDamage(damage);
    }

    // Coroutine to handle shooting
    private IEnumerator Shoot()
    {
        isShooting = true;
        while (target)
        {
            Bullet bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation).GetComponent<Bullet>();
            bullet.owner = Characters.Enemy;
            bullet.bulletDamage = 10; // Set the damage amount if needed
            yield return new WaitForSeconds(1f / fireRate);
        }
        isShooting = false;
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the collision is with the player
        PlayerController player = collision.GetComponent<PlayerController>();
        if (player) target = player.transform; // Set the player as the target
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        PlayerController player = collision.GetComponent<PlayerController>();
        if (player)
        {
            target = null;
            isShooting = false; // Reset the shooting flag
        }
    }
}
