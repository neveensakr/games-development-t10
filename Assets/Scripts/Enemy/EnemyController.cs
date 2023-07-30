using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float detectionRange = 2f;

    public GameObject grenade; // The bullet prefab
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
        if (target)
        {
            // Calculate the direction to the player and rotate towards it
            Vector3 direction = (target.position - transform.position).normalized;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            rb.rotation = angle - 90f;
            moveDirection = direction;
        }

        // Fire bullets at the player
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
            if (distance > detectionRange)
            {
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

    private void OnTriggerStay2D(Collider2D collision)
    {
         // Check if the collision is with the player
        PlayerController player = collision.GetComponent<PlayerController>();
        if (player)
        {
             // Calculate the distance to the player
            float distanceToPlayer = Vector2.Distance(transform.position, player.transform.position);
             // Check if the player is within the detection range
            if (distanceToPlayer <= detectionRange)
            {
                target = player.transform; // Set the player as the target
            }
        }
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
            GameObject bullet = Instantiate(grenade, firePoint.position, firePoint.rotation);
            bullet.GetComponent<Grenade>().grenadeDamage = 1; // Set the damage amount if needed
            yield return new WaitForSeconds(1f / fireRate);
        }
        isShooting = false;
    }
}


