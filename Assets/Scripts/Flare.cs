using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flare : MonoBehaviour
{
    public float hideFlareTime; // Fire rate in seconds
    private SpriteRenderer spriteRenderer;
    public bool flareActive = false;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        // if (spriteRenderer.enabled)
        // {
        //     StartCoroutine(HideFlare());
        // }
        if (flareActive)
        {
            spriteRenderer.enabled = true;
        }
        else
        {
            //StartCoroutine(HideFlare());
            //spriteRenderer.enabled = false;
        }
    }

    void LateUpdate()
    {
        if (!flareActive)
        {
            spriteRenderer.enabled = false;
        }
    }

    // Coroutine to handle shooting
    public IEnumerator HideFlare()
    {
        // flareActive = true;
        yield return new WaitForSeconds(hideFlareTime);
        flareActive = false;
        //spriteRenderer.enabled = false;
        //StopCoroutine(FlareManager());
    }
}
