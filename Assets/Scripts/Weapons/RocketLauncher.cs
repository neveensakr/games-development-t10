using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketLauncher : Weapon
{
    [SerializeField] public float cooldownTime = 3f; // Adjust as needed

    private bool canFire = true;

    private void Update()
    {
        if (!canFire)
        {
            // Reduce the cooldown timer
            cooldownTime -= Time.deltaTime;

            // Check if cooldown time is over
            if (cooldownTime <= 0f)
            {
                cooldownTime = 0f;
                canFire = true;
            }
        }
    }
    public override void Fire(GameObject rocketPrefab)
    {
        if (canFire)
        {
            Debug.Log("Rocket Launcher Firing!");
            for (var i = 1; i < this.gameObject.transform.childCount; i++) {
                this.gameObject.transform.GetChild(i).GetComponent<Flare>().flareActive = true;
                StartCoroutine(this.gameObject.transform.GetChild(i).GetComponent<Flare>().HideFlare());
            }
            Rocket bullet = Instantiate(rocketPrefab, FirePoint.position, FirePoint.rotation).GetComponent<Rocket>();
            bullet.owner = Characters.Player;
            bullet.rocketDamage = Damage;
            AudioManager.Instance.PlayerShootSound(); // Play the shooting sound
            canFire = false;
            cooldownTime = 3f;
        }
    }
}
