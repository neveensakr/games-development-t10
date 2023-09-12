using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private static AudioManager _instance;
    public static AudioManager Instance { get => _instance; }

    public AudioClip playerShootSound,  playerHitSound, playerDeathSound, enemyDefeatSound, playerSwitchWeaponSound, winSound, loseSound; // New sound effect clips
    public AudioSource effectAudioSource;

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }

    // When the player shoots an enemy
    public void PlayerShootSound()
    {
        effectAudioSource.Stop();
        effectAudioSource.clip = playerShootSound;
        effectAudioSource.Play();
    }

    // When the player is hit by an enemy's attack
    public void PlayerHitSound()
    {
        effectAudioSource.Stop();
        effectAudioSource.clip = playerHitSound;
        effectAudioSource.Play();
    }

    // When the player dies
    public void PlayerDeathSound()
    {
        effectAudioSource.Stop();
        effectAudioSource.clip = playerDeathSound;
        effectAudioSource.Play();
    }

     // When the player defeats an enemy
    public void EnemyDefeatSound()
    {
        effectAudioSource.Stop();
        effectAudioSource.clip = enemyDefeatSound;
        effectAudioSource.Play();
    }

     // When the player switches a weapon
    public void PlayerSwitchWeaponSound()
    {
        effectAudioSource.Stop();
        effectAudioSource.clip = playerSwitchWeaponSound;
        effectAudioSource.Play();
    }
    // When we win
    public void WinSound()
    {
        effectAudioSource.Stop();
        effectAudioSource.clip = winSound;
        effectAudioSource.Play();
    }
    // When we lose
    public void LoseSound()
    {
        effectAudioSource.Stop();
        effectAudioSource.clip = loseSound;
        effectAudioSource.Play();
    }

}
