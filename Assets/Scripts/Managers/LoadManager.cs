using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadManager : MonoBehaviour
{
    public static LoadManager Instance;

    private void Awake()
    {
        Instance = this;
    }
    
    public static IEnumerator StartRoutine()
    {
        // Create the camera and player.
        GameObject player = Instantiate(Resources.Load<GameObject>("Player"));
        GameObject camera = Instantiate(Resources.Load<GameObject>("Camera"));
        // Don't destroy them when switching scenes.
        Object.DontDestroyOnLoad(player);
        Object.DontDestroyOnLoad(camera);
        
        yield return Instance.StartCoroutine(LoadSceneRoutine("LoadingScene"));

        // Proceed depending on the current scene.
        Scene currentScene = SceneManager.GetActiveScene();
        switch (currentScene.name)
        {
            case "StartScene":
                Instance.StartCoroutine(StartSceneCoroutine());
                break;
            case "LoadingScene":
                LoadingScreenManager.Instance.EnableLoadingScreen();
                break;
            case "MainMenuScene":
                Instance.StartCoroutine(GoToMenu());
                break;
            case "HudScene":
                //Instance.StartCoroutine(InitalizeHud());
                break;
            default:
                Instance.StartCoroutine(GoToGame());
                break;
        }

        Debug.Log("Start Routine Finished");
        
        yield break;
    }
     
    public static IEnumerator StartSceneCoroutine()
    {
        LoadingScreenManager.Instance.EnableLoadingScreen();
        // TODO Deactivate player input.
        LoadingScreenManager.Instance.DisableLoadingScreen();

        Debug.Log("Start Scene Initialized");
        
        yield break;
    }
    
    public static IEnumerator GoToMenu()
    {
        // Set the loading scene as active
        SceneManager.SetActiveScene(SceneManager.GetSceneByName("LoadingScene"));
        LoadingScreenManager.Instance.EnableLoadingScreen();
        // TODO Deactivate player input before load.
        // It loads too fast, so wait a little
        if (SceneManager.GetSceneByName("StartScene").isLoaded)
        {
            // Unload the start scene as we don't need it.
            yield return Instance.StartCoroutine(UnloadSceneRoutine("StartScene"));
            yield return new WaitForSeconds(3);
        }
        
        yield return Instance.StartCoroutine(UnloadSceneRoutine("MainMenuScene"));
        yield return Instance.StartCoroutine(UnloadSceneRoutine("Extended Level"));

        // Load the menu scene.
        yield return Instance.StartCoroutine(LoadSceneRoutine("MainMenuScene"));
        // Set it as the active scene in case we need to instantiate anything it ends up in the correct scene.
        SceneManager.SetActiveScene(SceneManager.GetSceneByName("MainMenuScene"));
        // Remove the loading screen (fading out animation can be added here).
        LoadingScreenManager.Instance.DisableLoadingScreen();
        
        // TODO Enable player input.

        Debug.Log("Menu Initialized");

        yield break;
    }
    
    public static IEnumerator GoToGame()
    {
        // Set the loading scene as active
        SceneManager.SetActiveScene(SceneManager.GetSceneByName("LoadingScene"));
        LoadingScreenManager.Instance.EnableLoadingScreen();
        
        // TODO Deactivate player input before load.
        
        yield return Instance.StartCoroutine(UnloadSceneRoutine("MainMenuScene"));
        yield return Instance.StartCoroutine(UnloadSceneRoutine("Extended Level"));

        // Load the game scene and set it as the active scene.
        yield return Instance.StartCoroutine(LoadSceneRoutine("Extended Level"));
        SceneManager.SetActiveScene(SceneManager.GetSceneByName("Extended Level"));
        
        // TODO Load and initialize the hud scene.

        LoadingScreenManager.Instance.DisableLoadingScreen();
        // TODO Enable player input.

        Debug.Log("Game Initialized");

        yield break;
    }
    
    private static IEnumerator UnloadSceneRoutine(string sceneName)
    {
        // If the scene is loaded, unload it.
        if (SceneManager.GetSceneByName(sceneName).isLoaded)
            yield return SceneManager.UnloadSceneAsync(sceneName, UnloadSceneOptions.UnloadAllEmbeddedSceneObjects);

        yield break;
    }

    private static IEnumerator LoadSceneRoutine(string sceneName)
    {
        // If the scene is not loaded, load it.
        if (!SceneManager.GetSceneByName(sceneName).isLoaded)
            yield return SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);

        yield break;
    }
}
