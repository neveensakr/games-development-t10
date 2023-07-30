using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroySelf : MonoBehaviour
{
    [SerializeField]
    float seconds; // The duration (in seconds) after which the GameObject will be destroyed
    
    void Start()
    {
        // Destroy the GameObject to which this script is attached after the specified duration
        Destroy(gameObject, seconds);
    }
    
}
