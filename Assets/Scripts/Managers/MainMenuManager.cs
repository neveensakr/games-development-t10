using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuManager : MonoBehaviour
{
    public void GoToLevelOne()
    {
        Debug.Log("Game is opening...");
        LoadManager.Instance.StartCoroutine(LoadManager.GoToLevel1());
    }
    public void GoToLevelTwo()
    {
        Debug.Log("Game is opening...");
        LoadManager.Instance.StartCoroutine(LoadManager.GoToLevel2());
    }
    public void GoToLevelThree()
    {
        Debug.Log("Game is opening...");
        LoadManager.Instance.StartCoroutine(LoadManager.GoToLevel2());
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
