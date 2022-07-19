using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PassWord : MonoBehaviour
{

    public TextMeshProUGUI viewer;
    public int length;
   // Font font = Resources.GetBuiltinResource<Font>("Arial.ttf");
    
    // Start is called before the first frame update
    void Start()
    {
        // Viewer = GetComponent<TextMeshProUGUI>();
        viewer.text = "";
    }
    // Update is called once per frame
   

    private void Getvalue(string value)
    {     
        

        if(value == "del" )
        {
            viewer.text = "";
            return;
        }
       else if (value == "ok")
        {
           
            viewer.text = Check(viewer.text);
            return;
        }
      else if (viewer.text.Length >= length)
        {
            return;
        }
      
         viewer.text += value;
    }

    private string Check(string value)
    {
        if (value.Length < length)
            return "3글자 이상을 입력해주세요";

        else if (value == "1234")
            return "정답입니다!";
        else
            return "오답입니다.";
    }
}
