using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotGun : Weapon
{
    [SerializeField] public int numBullets = 10;
    [SerializeField] public float spreadAngle = 20f;
    [SerializeField] public float cooldownTime = 1f; // Adjust as needed

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
    
    public override void Fire(GameObject bulletPrefab)
    {
        if(canFire)
        {
            for (var i = 1; i < this.gameObject.transform.childCount; i++) {
                this.gameObject.transform.GetChild(i).GetComponent<Flare>().flareActive = true;
                StartCoroutine(this.gameObject.transform.GetChild(i).GetComponent<Flare>().HideFlare());
            }
            for (int i = 0; i < numBullets; i++)
            {
                Debug.Log("Shotgun Firing!");

                // Calculate half the spread angle
                float halfSpread = spreadAngle * 0.5f;

                // Generate random angles within the spread range for horizontal and vertical spread
                float horizontalAngle = UnityEngine.Random.Range(-halfSpread, halfSpread);
                float verticalAngle = UnityEngine.Random.Range(-halfSpread, halfSpread); // Adjust this range if needed

                // Calculate the bullet rotation
                Quaternion horizontalRotation = Quaternion.Euler(0f, horizontalAngle, 0f);
                Quaternion verticalRotation = Quaternion.Euler(verticalAngle, 0f, 0f);
                Quaternion bulletRotation = FirePoint.rotation * horizontalRotation * verticalRotation;

                // Instantiate the bullet wit
                Bullet bullet = Instantiate(bulletPrefab, FirePoint.position, bulletRotation).GetComponent<Bullet>();
                bullet.owner = Characters.Player;
                bullet.bulletDamage = Damage;
                AudioManager.Instance.PlayerShootSound(); // Play the shooting sound

                canFire = false;
                cooldownTime = 1f;
            }
        }
    }
}
