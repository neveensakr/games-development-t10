﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField]
    private float _movementSpeed;

    private Rigidbody2D rb;
    Ray mouseRay;
    Vector3 hitPoint;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (InputManager.InputActivated)
        {
            // convert mouse position into world coordinates
            Vector2 mouseScreenPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            // get direction you want to point at
            Vector2 direction = (mouseScreenPosition - (Vector2)transform.position).normalized;

            // set vector of transform directly
            transform.up = direction;
        }
    }

    private void FixedUpdate()
    {
        if (InputManager.InputActivated)
        {
            Vector2 movement = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
            if (movement.x == 0 && movement.y == 0) rb.velocity = new Vector2(0, 0);
            else rb.velocity = movement * _movementSpeed;
        }
    }
}
