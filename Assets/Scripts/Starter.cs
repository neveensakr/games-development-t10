using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Starter
{
    // bool to make sure this method runs only once.
    static bool _isInitialised = false;

    // This method will run once every time any scene is loaded.
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    static void OnSceneLoad()
    {
        if (_isInitialised) return;
        
        // Add a manger object that will contain the load manager.
        GameObject managerObj = new GameObject("Game Manager");
        managerObj.AddComponent<LoadManager>();
        managerObj.AddComponent<GameManager>();
        Object.DontDestroyOnLoad(managerObj); // So that the manager stays no matter the scene.
        // Start the start routine from the Load manager.
        LoadManager.Instance.StartCoroutine(LoadManager.StartRoutine());

        _isInitialised = true;
    }
}
