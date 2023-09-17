using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
// Importing the Element enum from Weapons/WeaponManager.cs

public class HudManager : MonoBehaviour
{
    public static HudManager Instance;
    public GameObject[] SecondaryWeapon;
    public GameObject[] PistolSkins;
    public GameObject[] AssaultRifleSkins;
    public GameObject[] ShotGunSkins;
    public GameObject[] RocketLauncher;

    public GameObject[] Fire;
    public GameObject[] Sheild;

    public GameObject[] Grenade;

    [SerializeField] private TextMeshProUGUI totalEnemies;
    [SerializeField] private TextMeshProUGUI remainingEnemies;

    public Image Slider;
    private int currentModelIndex = 0; // Index of the currently active model
    private string[] colors = new string[] { "#ED7D31", "#5B9BD5", "#BDD7EE" };

    // Start is called before the first frame update

    private Color HexToColor(string hex)
    {
        Color color = new Color();
        ColorUtility.TryParseHtmlString(hex, out color);
        return color;
    }

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(this);
    }

    void Start()
    {
        // Always start with fire
        SwitchSkins(0);
    }

    public void SwitchSkins(int newIndex)
    {
        Debug.Log("Switching Skins in Hud manager!");
        Color color = HexToColor(colors[newIndex]);
        // Changing Slider Color first
        Slider.color = color;

        // Loop through each element and deactivate the current 
        // model and activate the new model
        // Create an element list and loop through it for deactivate and active
        GameObject[][] elements = new GameObject[][] { SecondaryWeapon, Fire, Sheild, Grenade};

        foreach (GameObject[] element in elements)
        {
            element[currentModelIndex].SetActive(false);
            element[newIndex].SetActive(true);

            // Need to change the color of the image
            Image image = element[newIndex].GetComponent<Image>();
            image.color = color;
        }

        // Change the current model index to the new index
        currentModelIndex = newIndex;

    }

    public void SwitchWeapons(int newIndex)
    {
        SecondaryWeapon[currentModelIndex].SetActive(false);

        switch (newIndex)
        {
            case 0:
                SecondaryWeapon = PistolSkins;
                break;
            case 1:
                SecondaryWeapon = ShotGunSkins;
                break;
            case 2:
                SecondaryWeapon = AssaultRifleSkins;
                break;
            case 3:
                SecondaryWeapon = RocketLauncher;
                break;
        }
        
        SecondaryWeapon[currentModelIndex].SetActive(true);
        Image image = SecondaryWeapon[currentModelIndex].GetComponent<Image>();
        image.color = HexToColor(colors[currentModelIndex]);
    }

    public void SetupEnemyCount(int enemyCount) 
    { 
        if (enemyCount >= 0)
        {
            totalEnemies.SetText(enemyCount.ToString("00"));
            EnemyCountUpdate(enemyCount);
        } else
        {
            totalEnemies.SetText("No Enemies");
        }
    }
    public void EnemyCountUpdate(int enemyCount)
    {
       
        remainingEnemies.SetText(enemyCount.ToString("00"));
     
    }
}
