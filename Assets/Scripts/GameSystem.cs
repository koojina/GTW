using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class GameSystem : MonoBehaviour
{
    public enum ButtonType
    {
        NULL = -1, W, O, R, L, D, DEL, ENTER
    }

   Queue<GameObject> maskQueue = new Queue<GameObject>();

    public static GameSystem instance;
    public LayerMask layerMask;
    public Slider gauge;

    public static float maxValue = 100.0f;
    public bool full = false;
    public GameObject mask;
    public GameObject scratchObject;
    private Vector3 v;

    // public LayerMask layerMask;

    public TextMeshProUGUI viewer;
    public PasswordButton[] buttons;

    public Vector2[] buttonPosition;

    private List<int> randomPosition = new List<int>();

    private int add;

    [SerializeField]
    private int length;



    private void Awake()
    {
        instance = this;

        //��ư ��ġ ����
        for (int i = 0; i < length; ++i)
        {
            buttonPosition[i] = buttons[i].transform.position;
        }
    }

    void Start()
    {
        viewer.text = "";

        RandomPosition();


       
    }

    #region ������Ʈ����
    private void RandomPosition()
    {
        int curNumber = Random.Range(0, 5);

        while (add < length)
        {
            if (randomPosition.Contains(curNumber))
            {
                curNumber = Random.Range(0, length);
            }

            else
            {
                randomPosition.Add(curNumber);
                add++;
            }


        }
        SpawnPosition();
    }

    private void SpawnPosition()
    {
        for (int i = 0; i < length; ++i)
        {
            buttons[i].transform.position = buttonPosition[randomPosition[0]];
            randomPosition.RemoveAt(0);
        }


    }

    #endregion 

    #region ��ư����ý���

    public void GetButton(int value)
    {
        ButtonType buttonType = (ButtonType)value;

        string text = buttons[value].buttonText;

        string wrong = "��ȣ�� Ʋ�Ƚ��ϴ�";
        string correct = "����";
        if (buttonType == ButtonType.DEL)  //�ϳ��� ���ֱ�
        {
            if (viewer.text == wrong || viewer.text == "")
            {
                return;
            }
            viewer.text = viewer.text.Substring(0, viewer.text.Length - 1);

        }
        else if (buttonType == ButtonType.ENTER) //Ȯ�ι�ư
        {
            if (viewer.gameObject.activeSelf)
            {

                viewer.text = Check(viewer.text);
                HideButton();
                if (viewer.text == wrong)
                {

                    Invoke("Revalue", 1.0f);
                }
            }

        }
        else if (viewer.text != wrong || viewer.text != correct)
        {
            if (viewer.text.Length >= 10)
                return;
            viewer.text += buttonType.ToString();
        }
    }




    private string Check(string value)
    {

        string wrong = "��ȣ�� Ʋ�Ƚ��ϴ�";
        string correct = "����";
        if (value == "WORLD")
        {
            return correct;
        }
        else
        {
            return wrong;
        }


    }

    private void Revalue()
    {
        viewer.text = "";
        ShowButton();
    }

    #endregion
    private void ShowButton()
    {
        foreach (ButtonController button in buttons)
        {
            button.Show();
        }
    }

    private void HideButton()
    {
        foreach (ButtonController button in buttons)
        {

            button.Hide();
        }
    }



    #region ��ư�������ý���

    private void FullGauge()
    {
        full = true;
    }

    public void ClickGauge(float gaugeValue)
    {
        gauge.value += gaugeValue;

    }


    public void DragGauge(float gaugeValue)
    {
        gauge.value += gaugeValue;
        if (gauge.value >= gauge.maxValue)
        {
            FullGauge();
        }
    }
    #endregion

    #region ������Ʈ�̵�
    public void ObjectMove(RectTransform rectTansform, PointerEventData eventData)
    {
        if (full == false)
        {
            Vector2 currentPos = eventData.position;
            Vector2 pos = Camera.main.WorldToViewportPoint(transform.position);
            if (pos.x <= 0.2f)
            {
                pos.x = 0.2f;
            }
            else if (pos.x >= 0.8f)
            {
                pos.x = 0.8f;
            }
            if (pos.y <= 0.3f)
            {
                pos.y = 0.3f;
            }
            else if (pos.y >= 0.4f)
            {
                pos.y = 0.4f;
            }

            DragGauge(0.5f);
            transform.position = Camera.main.ViewportToWorldPoint(pos);
            rectTansform.anchoredPosition += eventData.delta;

        }

        else
        {
            Debug.Log("�Ϸ�");
        }
    }

    #endregion

    #region ��ũ��ġ

    public void Scratch()
    {
        var pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Ray2D ray = new Ray2D(pos, Vector2.zero);
        RaycastHit2D hit;

        hit = Physics2D.Raycast(ray.origin, ray.direction, Mathf.Infinity, layerMask);

        if (hit) //���콺 ��ó�� ������Ʈ�� �ִ��� Ȯ��
        {
            if (pos != v)
            {
                GameObject maskObj = Instantiate(mask, pos, Quaternion.identity);

                if (scratchObject == null)
                {
                    scratchObject = GameObject.Find("Scratch");
                }
                maskObj.transform.SetParent(scratchObject.transform);
                v = pos;
                
            }
        }
    }

    public void DelScratch()
    {
        scratchObject.SetActive(false);
    }


    #endregion
}
