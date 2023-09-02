using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ElementHealthBar : MonoBehaviour
{
    [SerializeField] public float maxElementTime = 10;
    [SerializeField] public Transform healthBarPosition;
    public float elementTime;
    public Element ActiveElement;
    [SerializeField] public Slider elementSlider;
    
    
    Camera cam;

    private void Start()
    {
        elementTime = 0;
        ActiveElement = Element.none;
        elementSlider.maxValue = maxElementTime;

        cam = GameManager.Camera.GetComponent<Camera>();
    }

    private void Update()
    {
        if (elementTime > 0)
        {
            Debug.Log("I am fricken here");
            elementTime -= Time.deltaTime;
            elementSlider.value = elementTime;
            Debug.Log(elementSlider.value);
        }
        Debug.Log(elementTime);

    }

    private void LateUpdate()
    {
        Vector2 screenPos = cam.WorldToScreenPoint(healthBarPosition.position);
        elementSlider.transform.position = screenPos;
        elementSlider.transform.rotation = healthBarPosition.rotation;
    }
}
