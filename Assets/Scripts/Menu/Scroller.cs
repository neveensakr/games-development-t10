using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scroller : MonoBehaviour
{
    [SerializeField] private RawImage image;
    [SerializeField] private float xAxis, yAxis;

    // Update is called once per frame
    void Update(){
    // Code for asteroid scroller
        image.uvRect = new Rect(image.uvRect.position + new Vector2(xAxis, yAxis) * Time.deltaTime, image.uvRect.size);
    }
}
