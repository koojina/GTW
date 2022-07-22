using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WindowSystem : UIController
{
    public GameObject wirteText;
    public GameObject WorldText;
    public GameObject enter;
    public GameObject In;
    public GameObject lightObj;
    public GameObject logView;
    public Image lightImage;

    public ButtonController buttonController;

   
    [SerializeField]
    private float lightTimer;
    void Start()
    {
        StartCoroutine("FadeIn");
        lightImage = lightObj.GetComponent<Image>();
        GameSystem.instance.nextSceneName = "Record02";
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }

    public override IEnumerator FadeIn()
    {
        yield return StartCoroutine(base.FadeIn());       
        enter.SetActive(true);
        In.SetActive(true);
        logView.SetActive(true);
    }

    public override IEnumerator FadeOut()
    {
        yield return StartCoroutine(base.FadeOut());
        
        GameSystem.instance.DelScratch();
        buttonController.ClickShow();
        In.SetActive(false);
        //loading ¶ç¿ì±â
        StartCoroutine("LightSprite");
    }

    public void StartFadeOut()
    {
        StartCoroutine("FadeOut");
        
    }

    public IEnumerator LightSprite()
    {
        yield return new WaitForSeconds(1.0f);
        lightObj.SetActive(true);
        Debug.Log("setactive");
        for (int i = 0; i < sprites.Length; i++)
        {   
            lightTimer += Time.deltaTime;
            lightImage.sprite = sprites[i];
            yield return new WaitForSeconds(1.0f);
        
        }
        wirteText.SetActive(true);
    }

    //public void StartWorld()
    //{
    //    WorldText.SetActive(true);

    //}
}
