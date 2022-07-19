using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainCanvas : UIController
{

    public UIController recordCanvas;
    public UIController collectionCanvas;
    public UIController optionCanvas;
    public UIController creditCanvas;
    private string[] valueDataString;
    public string[] keyDataString;

    
     void Start()
    {
        MenuData();
    }
    public void GameStartButton()
    {
        SceneManager.LoadScene("Loading");
        
    }

    public void RecordButton()
    {
        recordCanvas.OnUI();
    }

    public void CollectionButton()
    {
        collectionCanvas.OnUI();

    }
    public void OptionButton()
    {
        optionCanvas.OnUI();
    }
    public void CreditButton()
    {
        creditCanvas.OnUI();
    }

    public void MenuData()
    {
        valueDataString = new string[keyDataString.Length];
        
        for (int i = 0; i < keyDataString.Length; i++)
        {
            valueDataString[i] = DataRead.Instance.stringTable[keyDataString[i]];
        }
        ReadStringKey(valueDataString);
    }

    



}
