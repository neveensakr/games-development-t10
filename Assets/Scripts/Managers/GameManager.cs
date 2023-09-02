using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public static GameObject Player { get; set; }
    public static int CurrentLevel = 1;
    public static bool GamePaused = false;
    private int enemyCount;
    public static GameObject Camera { get; set; }

    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && PauseMenuManager.Instance && !EndScreenManager.IsActive)
        {
            if (GamePaused) PauseMenuManager.Instance.ResumeGame();
            else PauseMenuManager.Instance.PauseGame();
        }
    }

    public void SetupLevel(int levelNumber)
    {
        CurrentLevel = levelNumber;
        enemyCount = FindObjectsOfType<EnemyHealth>().Length;
        Player.SetActive(true);
    }

    public void CheckIfWon(GameObject enemy)
    {
        enemyCount--;
        Debug.Log("enemyCount" + enemyCount);
        if (enemyCount == 0)
        {
            Debug.Log("PLAYER WON");
            CurrentLevel++;
            EndScreenManager.Instance.Setup(true);
        }
    }

    public void DisableEnemies()
    {
        foreach (EnemyHealth enemy in FindObjectsOfType<EnemyHealth>())
        {
            enemy.gameObject.SetActive(false);
        }
    }
}
