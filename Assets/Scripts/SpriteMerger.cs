using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteMerger : MonoBehaviour
{
    [SerializeField] private SpriteRenderer[] spritesToMerge = null;
    [SerializeField] private SpriteRenderer finalSpriteMask = null;

    public bool isTest = false;

    private void Update()
    {
        if(isTest)
        {
            Merge();
            isTest = false;
        }
    }

    private void Merge()
    {
        Resources.UnloadUnusedAssets();
        Texture2D newTex = new Texture2D(1080,1920);

        for (int x = 0; x < newTex.width; x++)
        {
            for (int y = 0; y < newTex.height; y++)
            {
                newTex.SetPixel(x, y, new Color(1, 1, 1, 0));
            }
        }

        for (int i = 0; i < spritesToMerge.Length; i++)
        {
            for (int x = -((1080 / 2) - spritesToMerge[i].sprite.texture.width/2); x < ((1080 / 2) - spritesToMerge[i].sprite.texture.width/2); x++)
            {
                for (int y = -((1920 / 2) - spritesToMerge[i].sprite.texture.width/2); y < ((1920 / 2) - spritesToMerge[i].sprite.texture.width/2); y++)
                {
                    var color = spritesToMerge[i].sprite.texture.GetPixel(x, y).a == 0 ? newTex.GetPixel(x, y) : spritesToMerge[i].sprite.texture.GetPixel(x, y);

                    newTex.SetPixel(x,y,color);
                }
            }
        }


        newTex.Apply();
        var finalSprite = Sprite.Create(newTex, new Rect(0, 0, newTex.width, newTex.height), new Vector2(0.5f, 0.5f));
        finalSprite.name = "New Sprite";
        finalSpriteMask.sprite = finalSprite;

    }
}
