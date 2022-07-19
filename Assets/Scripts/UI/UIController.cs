using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public abstract class UIController : MonoBehaviour
{
    public Canvas canvas;
    public GraphicRaycaster graphicRaycaster;
    public TextMeshProUGUI[] textMeshPro;
  

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
     
        for (int i=0; i<dataString.Length;i++)
        {
            textMeshPro[i].text= dataString[i];
        }
    }

   
}
