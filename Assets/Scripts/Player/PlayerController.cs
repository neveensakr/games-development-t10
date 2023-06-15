using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private GrenadeShooter shooter;

    // Start is called before the first frame update
    void Start()
    {
        shooter = GetComponent<GrenadeShooter>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            shooter.Fire();
        }
    }
}
