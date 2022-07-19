using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AlphaButton : MonoBehaviour
{
    public Button alphaButton;
    public Image alphaImage;

    public float alphaThreshold;
    // Start is called before the first frame update
    void Start()
    {
        alphaButton = GetComponent<Button>();
        alphaImage = GetComponent<Image>();

        AlphaBtnSet();
    }

    public  void AlphaBtnSet()
    {
        alphaThreshold = 0.1f;
        Debug.Log("AlphaStart");
        alphaImage.alphaHitTestMinimumThreshold = alphaThreshold;
    }
}
