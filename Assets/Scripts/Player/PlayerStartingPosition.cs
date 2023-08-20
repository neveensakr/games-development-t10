using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStartingPosition : MonoBehaviour
{
    private void Start()
    {
        Transform playerTransform = GameManager.Player.transform; // Get player's transform from GameManager
        playerTransform.position = transform.position; // Set player's position to this GameObject's position
    }
}
