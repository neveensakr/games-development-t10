using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndScreenManager : MonoBehaviour
{
    [SerializeField] private GameObject screen;
    [SerializeField] private GameObject nextLevelBtn;
    [SerializeField] private TextMeshProUGUI resultTxt;
    public static EndScreenManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        screen.SetActive(false);
    }

    public void Setup(bool won)
    {
        screen.SetActive(true);
        GameManager.Instance.DisableEnemies();
        InputManager.DeactivateInput();
        SceneManager.SetActiveScene(SceneManager.GetSceneByName("EndScreenScene"));
        if (won)
        {
            resultTxt.SetText("Success!");
            if (GameManager.CurrentLevel == 4)
            {
                nextLevelBtn.SetActive(false);
            }
        }
        else
        {
            resultTxt.SetText("Hard Luck!");
            nextLevelBtn.GetComponentInChildren<TextMeshProUGUI>().SetText("Try Again");
        }
    }

    public void GoToNextLevel()
    {
        Debug.Log("Next Level Opening...");
        
        switch (GameManager.CurrentLevel)
        {
            case 1:
                LoadManager.Instance.StartCoroutine(LoadManager.GoToLevel1());
                break;
            case 2:
                LoadManager.Instance.StartCoroutine(LoadManager.GoToLevel2());
                break;
            case 3:
                LoadManager.Instance.StartCoroutine(LoadManager.GoToLevel3());
                break;
        }
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
