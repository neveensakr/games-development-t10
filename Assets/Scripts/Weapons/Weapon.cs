using System;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    [SerializeField] public Transform FirePoint;
    [SerializeField] public int Damage;
    [SerializeField] public Element[] Elements;
    [SerializeField] public Sprite[] Skins;
    [SerializeField] public Sprite[] FlareSprites;
    
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
        for (var i = 1; i < this.gameObject.transform.childCount; i++) {
            this.gameObject.transform.GetChild(i).GetComponent<SpriteRenderer>().sprite = FlareSprites[Array.IndexOf(Elements, element)];
        }
    }
}
