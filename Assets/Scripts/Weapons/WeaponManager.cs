using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Element
{
    Frost, 
    Lightning,
    Fire
}

public class WeaponManager : MonoBehaviour
{
    public Element ActiveElement;
    public Weapon ActiveWeapon;
    public GameObject ActiveBullet;
    [SerializeField] public GameObject ActiveRocket;
    
    [SerializeField] public GameObject[] Weapons;
    [SerializeField] public Element[] Elements;
    [SerializeField] public Sprite[] Skins;
    [SerializeField] public GameObject[] Arms;
    [SerializeField] public GameObject[] Bullets;
    [SerializeField] public GameObject[] Rockets;

    private int _currentWeaponIndex;
    private PlayerHealth _playerHealth;

    private void Start()
    {
        ActiveElement = Element.Fire;
        ActiveBullet = Bullets[Array.IndexOf(Elements, ActiveElement)];
        ActiveRocket = Rockets[Array.IndexOf(Elements, ActiveElement)];

        foreach (GameObject weapon in Weapons) weapon.GetComponent<Weapon>().Deactivate();
        ActiveWeapon = Weapons[0].GetComponent<Weapon>();
        ActiveWeapon.Activate();
        _currentWeaponIndex = 0;
        
        foreach (GameObject arm in Arms) arm.SetActive(false);
        Arms[Array.IndexOf(Elements, ActiveElement)].SetActive(true);
        
        _playerHealth = GetComponent<PlayerHealth>();
    }

    private void Update()
    {
        if (InputManager.InputActivated && _playerHealth.GetCurrentHealth() > 0f)
        {
            if (Input.GetKeyDown(KeyCode.Q) || Input.mouseScrollDelta.y > 0.8f) SwitchWeapons();
            else if (Input.GetMouseButtonDown(0) && ActiveWeapon is RocketLauncher) ActiveWeapon.Fire(ActiveRocket); 
            else if (Input.GetMouseButton(0) && ActiveWeapon is AssaultRifle) ActiveWeapon.Fire(ActiveBullet); 
            else if (Input.GetMouseButtonDown(0)) ActiveWeapon.Fire(ActiveBullet); 
            else if (Input.GetKeyDown(KeyCode.Alpha1)) SwitchElement(Element.Fire);
            else if (Input.GetKeyDown(KeyCode.Alpha2)) SwitchElement(Element.Lightning);
            else if (Input.GetKeyDown(KeyCode.Alpha3)) SwitchElement(Element.Frost);
        }
    }

    private void SwitchWeapons()
    {
        ActiveWeapon.Deactivate();
        int nextIndex = (_currentWeaponIndex + 1 >= Weapons.Length) ? 0 : ++_currentWeaponIndex;
        ActiveWeapon = Weapons[nextIndex].GetComponent<Weapon>();
        ActiveWeapon.Activate();
        ActiveWeapon.SwitchSkins(ActiveElement);
        _currentWeaponIndex = nextIndex;
    }

    private void SwitchElement(Element element)
    {
        Arms[Array.IndexOf(Elements, ActiveElement)].SetActive(false);
        ActiveElement = element;
        int nextIndex = Array.IndexOf(Elements, element);
        GetComponent<SpriteRenderer>().sprite = Skins[nextIndex];
        Arms[nextIndex].SetActive(true);
        ActiveWeapon.SwitchSkins(ActiveElement);
        ActiveBullet = Bullets[Array.IndexOf(Elements, ActiveElement)];
        ActiveRocket = Rockets[Array.IndexOf(Elements, ActiveElement)];
    }
}
