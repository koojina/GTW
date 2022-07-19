using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeInOut : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public float alpha;

    void Start()
    {
        StartCoroutine("FadeIn");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("a"))
            StartCoroutine("FadeIn");
        if (Input.GetKeyDown("s"))
            StartCoroutine("FadeOut");
    }

    IEnumerator FadeIn()
    {
        
        for (alpha = 0; alpha < 1.01; alpha+=0.1f)
        {
            Color spriteColor = spriteRenderer.material.color;
                spriteColor.a = alpha;
                spriteRenderer.material.color = spriteColor;
            yield return new WaitForSeconds(0.1f);

        }
    }

    IEnumerator FadeOut()
    {
        for (int i=10; i>=0; i--)
        {
            float alpha = i / 10.0f;
            Color spriteColor = spriteRenderer.material.color;
            spriteColor.a = alpha;
            spriteRenderer.material.color = spriteColor;
            yield return new WaitForSeconds(0.1f);
        }
    }
}
