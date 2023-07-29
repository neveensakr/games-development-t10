using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuManager : MonoBehaviour
{
    public void GoToGameBtn()
    {
        Debug.Log("Game is opening...");
        LoadManager.Instance.StartCoroutine(LoadManager.GoToGame());
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
