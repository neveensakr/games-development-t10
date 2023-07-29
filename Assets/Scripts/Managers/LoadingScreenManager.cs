using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadingScreenManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _loadingCanvas;

    public static LoadingScreenManager Instance;

    private void Awake()
    {
        Instance = this;
        _loadingCanvas.SetActive(false);
    }

    public void EnableLoadingScreen()
    {
        _loadingCanvas.SetActive(true);
    }

    public void DisableLoadingScreen()
    {
        _loadingCanvas.SetActive(false);
    }
}
