using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PasswordButton : ButtonController
{
    
    public override void ClickShow()
    {
        button.interactable = true;
    }

    public override void ClickHide()
    {
        button.interactable = false;
    }

    public override void Show()
    {      
            gameObject.SetActive(true);     
    }

    public override void Hide()
    {

        gameObject.SetActive(false);
        
    }
}
