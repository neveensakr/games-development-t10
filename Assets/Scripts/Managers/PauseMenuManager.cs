using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuManager : MonoBehaviour
{
    [SerializeField] private GameObject screen;
    public static PauseMenuManager Instance;

    private void Awake()
    {
        Instance = this;
    }
    
    private void Start()
    {
        screen.SetActive(false);
    }
    
    public void PauseGame()
    {
        GameManager.GamePaused = true;
        InputManager.DeactivateInput();
        screen.SetActive(true);
        Time.timeScale = 0;
        Debug.Log("Game Paused!");
    }

    public void ResumeGame()
    {
        screen.SetActive(false);
        InputManager.ActivateInput();
        Time.timeScale = 1;
        GameManager.GamePaused = false;
        Debug.Log("Game Resumed!");
    }
    
    public void GoToMenu()
    {
        Debug.Log("Going to Menu...");
        LoadManager.Instance.StartCoroutine(LoadManager.GoToMenu());
    }
    
    public void ExitBtn()
    {
        Debug.Log("Exiting Game");
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#elif (UNITY_STANDALONE) 
         Application.Quit();
#endif
    }
}
