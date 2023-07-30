using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Transform player;

    public Vector3 offset;

    private void Start()
    {
        player = FindObjectOfType<PlayerController>().transform;
    }

    void Update()
    {
        transform.position = player.position + offset;
    }
}
