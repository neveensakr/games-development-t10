using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogoToMenu : MonoBehaviour
{
    public void GoToMenu()
    {
        LoadManager.Instance.StartCoroutine(LoadManager.GoToMenu());
    }
}
