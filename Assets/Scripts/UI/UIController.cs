using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public abstract class UIController : MonoBehaviour
{
    public Canvas canvas;
    public GraphicRaycaster graphicRaycaster;
    public TextMeshProUGUI[] textMeshPros;
    public SpriteRenderer spriteRenderer;
    public Sprite[] sprites;
    
   
    public float alpha { get; set; }
    public float delay { get; set; }
    public virtual void OffUI()
    {
        canvas.enabled = false;
        graphicRaycaster.enabled = false;
    }

    public virtual void OnUI()
    {
        canvas.enabled = true;
        graphicRaycaster.enabled = true;
    }

    public virtual void ReadStringKey(string[] dataString)
    {

        for (int i = 0; i < dataString.Length; i++)
        {
            textMeshPros[i].text = dataString[i];
        }
    }

    public virtual IEnumerator FadeIn()
    {
    
        float time = 0;
        delay = 2f;
        while (time < 1)
        {
            time += Time.deltaTime / delay;

            alpha = Mathf.Lerp(0f, 1f, time);
            Color spriteColor = spriteRenderer.material.color;
            spriteColor.a = alpha;
            spriteRenderer.material.color = spriteColor;
            yield return null;
        }

    }
    public virtual IEnumerator FadeOut()
    {
        float time = 0;
        while(time <1)
        {
            time += Time.deltaTime / delay;
            alpha = Mathf.Lerp(1f, 0f, time);
            Color spriteColor = spriteRenderer.material.color;
            spriteColor.a = alpha;
            spriteRenderer.material.color = spriteColor;
            yield return null;
        }
    }
}