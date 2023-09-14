using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
// Importing the Element enum from Weapons/WeaponManager.cs

public class HudManager : MonoBehaviour
{
    public static HudManager Instance;
    public GameObject[] PrimaryWeapon;
    public GameObject[] SecondaryWeapon;

    public GameObject[] Fire;
    public GameObject[] Sheild;

    public GameObject[] Grenade;

    public GameObject[] PauseButton;

    public CanvasRenderer BooletCount;
    public CanvasRenderer GranaideCount;
    public CanvasRenderer Slider;
    private int currentModelIndex = 0; // Index of the currently active model
    private string[] colors = new string[] { "#ED7D31", "#5B9BD5", "#BDD7EE" };

    // Start is called before the first frame update

    private Color HexToColor(string hex)
    {
        Color color = new Color();
        ColorUtility.TryParseHtmlString(hex, out color);
        return color;
    }

    private void Awake(){
        if (Instance == null)
            Instance = this;
        else
            Destroy(this);
    }

    void Start()
    {

        // SwitchSkins(2);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SwitchSkins(int newIndex)
    {
        Debug.Log("Switching Skins in Hud manager!");
        PrimaryWeapon[currentModelIndex].SetActive(false);
        SecondaryWeapon[currentModelIndex].SetActive(false);
        Fire[currentModelIndex].SetActive(false);
        Sheild[currentModelIndex].SetActive(false);
        Grenade[currentModelIndex].SetActive(false);
        PauseButton[currentModelIndex].SetActive(false);

        currentModelIndex = newIndex;

        PrimaryWeapon[currentModelIndex].SetActive(true);
        SecondaryWeapon[currentModelIndex].SetActive(true);
        Fire[currentModelIndex].SetActive(true);
        Sheild[currentModelIndex].SetActive(true);
        Grenade[currentModelIndex].SetActive(true);
        PauseButton[currentModelIndex].SetActive(true);

        // Change color of text and others
        Color color = HexToColor(colors[currentModelIndex]);
        Image[] images = FindObjectsOfType<Image>();

        // Change the color of each Text component
        foreach (Image image in images)
        {
            image.color = color;
        }
    }
}
