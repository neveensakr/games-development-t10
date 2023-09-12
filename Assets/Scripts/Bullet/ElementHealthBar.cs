using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ElementHealthBar : MonoBehaviour
{
    [SerializeField] public float maxElementTime = 10;
    [SerializeField] public Transform healthBarPosition;
    [SerializeField] public Image sliderFill;
    [SerializeField] public Color[] sliderColors;
    [SerializeField] public Slider elementSlider;
    [SerializeField] public float timeAtMax;
    
    public float elementTime;
    public bool AtPeakTime = false;
    public Element ActiveElement;
    
    private bool elementDecreasing = false;
    private Camera cam;
    
    private void Start()
    {
        elementTime = 0;
        ActiveElement = Element.none;
        elementSlider.maxValue = maxElementTime;

        cam = GameManager.Camera.GetComponent<Camera>();
    }

    private void Update()
    {
        elementSlider.value = elementTime;
        if (elementTime > 0 && !elementDecreasing)
        {
            StartCoroutine(DecreaseHealth());
        }
        else if (ActiveElement != Element.none && elementTime <= 0)
        {
            ChangeElement(Element.none);
        }
    }

    private void LateUpdate()
    {
        Vector2 screenPos = cam.WorldToScreenPoint(healthBarPosition.position);
        elementSlider.transform.position = screenPos;
        elementSlider.transform.rotation = healthBarPosition.rotation;
    }

    public void ChangeElement(Element newElement)
    {
        ActiveElement = newElement;
        switch (ActiveElement)
        {
            case Element.Fire:
                sliderFill.color = sliderColors[0];
                break;
            case Element.Lightning:
                sliderFill.color = sliderColors[1];
                break;
            case Element.Frost:
                sliderFill.color = sliderColors[2];
                break;
            case Element.none:
                sliderFill.color = sliderColors[3];
                break;
        }
    }

    private IEnumerator DecreaseHealth()
    {
        while (elementTime > 0)
        {
            if (elementTime >= maxElementTime)
            {
                AtPeakTime = true;
                yield return new WaitForSeconds(timeAtMax);
                AtPeakTime = false;
                elementTime = 0;
                if (GetComponent<EnemyController>()) {
                    GetComponent<EnemyController>().ResetSpeed();
                }
                else {
                    GetComponent<EnemyFourArms>().ResetSpeed();
                }
                
                GameObject frostEffect = this.gameObject.transform.GetChild(3).gameObject;
                frostEffect.GetComponent<SpriteRenderer>().enabled = false;
            }
            elementDecreasing = true;
            elementTime--;
            
            yield return new WaitForSeconds(0.5f);
        }
        elementDecreasing = false;
        yield break;
    }
    public void Explode(float explosionRadius, int damage)
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, explosionRadius);
        foreach (Collider2D collider in colliders)
        {
            if (collider.isTrigger) continue;
            EnemyHealth enemiesHealth = collider.gameObject.GetComponent<EnemyHealth>();
            if (enemiesHealth != null)
            {
                enemiesHealth.TakeDamage(damage);
            }

            // Instantiate explosion effect
        }
    }
}
