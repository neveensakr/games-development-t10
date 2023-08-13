using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scroller : MonoBehaviour
{
    [SerializeField] private RawImage image;
    [SerializeField] private float x_axis, y_axis;

    // Update is called once per frame
    void Update(){
    // Code for asteroid scroller
        image.uvRect = new Rect(image.uvRect.position + new Vector2(x_axis, y_axis) * Time.deltaTime, image.uvRect.size);
    }
}
