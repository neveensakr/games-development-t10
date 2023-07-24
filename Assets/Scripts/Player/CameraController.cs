using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private Transform player;

    public Vector3 offset;

    void Update()
    {
        transform.position = player.position + offset;
    }
}
