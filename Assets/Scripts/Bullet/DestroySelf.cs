﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroySelf : MonoBehaviour
{
    [SerializeField]
    float seconds;
    
    void Start()
    {
        Destroy(gameObject, seconds);
    }
    
}
