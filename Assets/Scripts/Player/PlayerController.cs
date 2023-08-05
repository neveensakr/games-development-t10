using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private BulletShooter shooter;

    void Start()
    {
        shooter = GetComponent<BulletShooter>();
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
