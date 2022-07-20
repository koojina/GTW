using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class ButtonController : MonoBehaviour
{
    public Button button;
    public GameObject buttonObj;
  
    public string buttonText { get; private set; }

  
    private void Start()
    {
        button = GetComponent<Button>();
       

    }
    public virtual void ClickHide() { }
    public virtual void ClickShow() { }

    public virtual void Show() { }
    public virtual void Hide() { }
   
}
