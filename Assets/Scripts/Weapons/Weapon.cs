using System;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    [SerializeField] public Transform FirePoint;
    [SerializeField] public int Damage;
    [SerializeField] public Element[] Elements;
    [SerializeField] public Sprite[] Skins;
    
    public bool IsActive;
    
    public void Activate()
    {
        GetComponent<SpriteRenderer>().enabled = true;
        IsActive = true;
    }
    
    public void Deactivate()
    {
        GetComponent<SpriteRenderer>().enabled = false;
        IsActive = false;
    }
    
    public abstract void Fire(GameObject bulletPrefab);

    public void SwitchSkins(Element element)
    {
        Debug.Log("Switching Skins!");
        Sprite newSkin = Skins[Array.IndexOf(Elements, element)];
        GetComponent<SpriteRenderer>().sprite = newSkin;
    }
}
