using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFourArms : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float minDistanceToPlayer = 1f; // Minimum distance to maintain from the player

    

    private Transform target;
    private Vector2 moveDirection;
    private Rigidbody2D rb;
    private EnemyHealth enemyHealth;
    private bool canPunch = false;
    private Animator animator;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        enemyHealth = GetComponent<EnemyHealth>(); // Assign the EnemyHealth component
        animator = GetComponent<Animator>();
        animator.speed = 0;
        ToggleDamageForHands(false);
    }

    private void Update()
    {
        if (canPunch)
        {
            animator.speed = 1;
            ToggleDamageForHands(true);
        }
        else
        {
            animator.Play("Enemy (FourArms)", -1, 0f);
            animator.speed = 0;
            ToggleDamageForHands(false);
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
                canPunch = false;
            }
            else
            {
                rb.velocity = Vector2.zero; // Stop moving if within the detection range
                canPunch = true;
            }
            
        }
        else
        {
            rb.velocity = Vector2.zero; // Stop moving if there is no target
            canPunch = false;
        }
    }

    // Call this method when the enemy needs to deal damage
    public void DealDamage(int damage)
    {
        enemyHealth.TakeDamage(damage);
    }

    // Call this method when the enemy to toggle if damage is going to be dealt
    public void ToggleDamageForHands(bool canDamage)
    {
        for (var i = 0; i < 4; i++)
        {
            BoxCollider2D child = this.gameObject.transform.GetChild(i).gameObject.GetComponent<BoxCollider2D>();
            child.enabled = canDamage;
        }
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
            //canPunch = false; // Reset the punching flag
        }
    }
}
