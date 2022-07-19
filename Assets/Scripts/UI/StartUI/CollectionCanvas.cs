using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectionCanvas : UIController
{
    private string[] valueDataString;
    public string[] keyDataString;

     void Start()
    {
        CollectionButton();
    }

    public void CollectionButton()
    {
        valueDataString = new string[keyDataString.Length];
        for(int i=0;i< keyDataString.Length;i++)
        {
            valueDataString[i] = DataRead.Instance.stringTable[keyDataString[i]];
        }
        ReadStringKey(valueDataString);
    }

    public void ExitCanvas()
    {
        this.OffUI();
    }


}
