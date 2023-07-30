using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private GrenadeShooter shooter;

    void Start()
    {
        shooter = GetComponent<GrenadeShooter>();
    }

    void Update()
    {
        if (InputManager.InputActivated)
        {
            if (Input.GetMouseButtonDown(0))
            {
                shooter.Fire();
            }
        }
    }
}
