// using System;
// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class CameraController : MonoBehaviour
// {
//     private Transform player;

//     public Vector3 offset;

//     private void Start()
//     {
//         player = FindObjectOfType<PlayerController>().transform;
//     }

//     void Update()
//     {
//         transform.position = player.position + offset;
//     }
// }

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float smoothSpeed = 0.125f;
    public float cameraZOffset = -10f; // The offset on the z-axis to adjust the camera's position

    private Transform player;

    private void Start()
    {
        player = FindObjectOfType<PlayerController>().transform;
    }

    private void LateUpdate()
    {
        if (player != null)
        {
            Vector3 desiredPosition = new Vector3(player.position.x, player.position.y, cameraZOffset);
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            transform.position = smoothedPosition;
        }
    }
}



