using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LoadingCanvas : UIController
{
    private string[] valueDataString;
    public string[] keyDataString;
   
    public int cnt;
    string currentText;
   // public TextMeshProUGUI writeText;
    
    // Start is called before the first frame update
    void Start()
    {
        LoadingText();
       
    }

    public void LoadingText()
    {
        valueDataString = new string[keyDataString.Length];

        for (int i = 0; i < keyDataString.Length; i++)
        {
            valueDataString[i] = DataRead.Instance.stringTable[keyDataString[i]];
        }
        // ReadStringKey(valueDataString);
        StartCoroutine(ShowText(valueDataString));
    }

    IEnumerator ShowText(string[] _fullText)
    {
        delay = 2f;
        currentText = "";
        for (int i = _fullText[0].Length-4; i < _fullText[0].Length; i++)
        {
            currentText = _fullText[0].Substring(0, i + 1);
            textMeshPros[0].text = currentText;
            yield return new WaitForSeconds(delay);
            if (i == _fullText[0].Length - 1)
                i = _fullText[0].Length - 5;
        }
    }

}

