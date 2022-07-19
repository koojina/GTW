using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Controller : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler, IPointerClickHandler
{   public FillChecker fillChecker;
    public WindowSystem windowSystem;


    public static Vector2 DefaultPos;   
    private RectTransform rectTansform;
    public GameObject In;
    
 
    void Awake()
    {
        rectTansform = GetComponent<RectTransform>();

    }

    void Update()
    {
        if (In.activeSelf && fillChecker.check == false)
        {
            if (DustGetMouse())
            {
                GameSystem.instance.Scratch();
            }
        }

      if (GameSystem.instance.full == true)
        {
            transform.position = Vector2.MoveTowards(transform.position, DefaultPos, 0.001f);

        }


    }

    void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
    {
       
    }

    void IBeginDragHandler.OnBeginDrag(PointerEventData eventData)
    {
        DefaultPos = this.transform.position;
    }

    void IDragHandler.OnDrag(PointerEventData eventData)
    {
       // Vector2 currentPos = eventData.position;
       
        //rectTansform.anchoredPosition += eventData.delta;


    }

    void IEndDragHandler.OnEndDrag(PointerEventData eventData)
    {
       if (GameSystem.instance.full == false)
        {
            transform.position = DefaultPos;
        }

    }

    private bool DustGetMouse()
    {
        if(Input.GetMouseButton(0))
        {
            if (fillChecker.RayChecker() && fillChecker.check == false)
            {
                fillChecker.check = true;
                windowSystem.StartFadeOut();
            }
            return true;
        }
        else if(Input.GetMouseButtonUp(0))
        {
          
            return false;
        }
        return false;
    }
}