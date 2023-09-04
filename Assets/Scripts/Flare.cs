using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flare : MonoBehaviour
{
    public float hideFlareTime; // Fire rate in seconds
    private SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (spriteRenderer.enabled)
        {
            StartCoroutine(HideFlare());
        }
    }

    // Coroutine to handle shooting
    private IEnumerator HideFlare()
    {
        yield return new WaitForSeconds(hideFlareTime);
        spriteRenderer.enabled = false;
    }
}
