using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class ButtonController : MonoBehaviour
{
    public Button button;
   
    public string buttonText { get; private set; }

  
    private void Start()
    {
        button = GetComponent<Button>();
        

    }
    public virtual void Hide() { }
    public virtual void Show() { }

    
}
