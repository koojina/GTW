using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PasswordButton : ButtonController
{
    public override void Show()
    {
        button.interactable = true;
    }

    public override void Hide()
    {
        button.interactable = false;
    }

  
}
