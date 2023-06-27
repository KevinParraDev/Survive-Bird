using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeDifficulty : MonoBehaviour
{
    public SpriteRenderer climbPlantL;
    public SpriteRenderer climbPlantR;
    public SpriteRenderer climbPlantD;
    public SpriteRenderer climbPlantU;

    public SpriteRenderer sky;

    public SpriteRenderer cloud1;
    public SpriteRenderer cloud2;
    public SpriteRenderer cloud3;
    public SpriteRenderer cloud4;

    public Image[] cloudsToChangeScene;

    public SpriteRenderer[] knifes;
    public SpriteRenderer[] axes;
    public SpriteRenderer[] coins;
    public Animator[] fires;

    public Sprite[] cPlantSprites;
    public Sprite[] cPlantHSprites;
    public Sprite[] skySprites;
    public Sprite[] knifeSprites;
    public Sprite[] axeSprites;
    public Sprite[] coinSprites;
    public RuntimeAnimatorController[] fireAnimators;

    Color g1 = new Color(0.372549f, 0.6588235f, 0.6156863f);
    Color g2 = new Color(0.5490196f, 0.8431373f, 0.8000001f);
    Color g3 = new Color(0.7098039f, 0.9333334f, 0.9019608f);
    Color g4 = new Color(0.7843138f, 0.9686275f, 0.9450981f);

    Color r1 = new Color(0.7882354f, 0.4666667f, 0.3176471f);
    Color r2 = new Color(0.9411765f, 0.7764707f, 0.7176471f);
    Color r3 = new Color(0.9411765f, 0.5372549f, 0.3607843f);
    Color r4 = new Color(0.8588236f, 0.6470588f, 0.5686275f);

    Color p4 = new Color(0.8078432f, 0.7803922f, 0.8862746f);
    Color p3 = new Color(0.6980392f, 0.654902f, 0.8313726f);
    Color p2 = new Color(0.5843138f, 0.5372549f, 0.7411765f);
    Color p1 = new Color(0.4352942f, 0.3607843f, 0.6784314f);


    public void ChangeSceneClouds(int difficult)
    {
        if(difficult == 0)
        {
            cloudsToChangeScene[3].color = g1;
            cloudsToChangeScene[2].color = g2;
            cloudsToChangeScene[1].color = g3;
            cloudsToChangeScene[0].color = g4;
        }
        if (difficult == 1)
        {
            cloudsToChangeScene[3].color = r1;
            cloudsToChangeScene[2].color = r2;
            cloudsToChangeScene[1].color = r3;
            cloudsToChangeScene[0].color = r4;
        }
        if (difficult == 2)
        {
            cloudsToChangeScene[3].color = p1;
            cloudsToChangeScene[2].color = p2;
            cloudsToChangeScene[1].color = p3;
            cloudsToChangeScene[0].color = p4;
        }
    }

    public void Change(int difficult)
    {
        climbPlantL.sprite = cPlantSprites[difficult];
        climbPlantR.sprite = cPlantSprites[difficult];
        climbPlantD.sprite = cPlantHSprites[difficult];
        climbPlantU.sprite = cPlantHSprites[difficult];
        sky.sprite = skySprites[difficult];

        if (difficult == 0)
        {
            cloud1.color = g1;
            cloud2.color = g2;
            cloud3.color = g3;
            cloud4.color = g4;
        }
        else if(difficult == 1)
        {
            cloud1.color = r1;
            cloud2.color = r2;
            cloud3.color = r3;
            cloud4.color = r4;
        }
        else if (difficult == 2)
        {
            cloud1.color = p1;
            cloud2.color = p2;
            cloud3.color = p3;
            cloud4.color = p4;
        }

        for (int i = 0; i < knifes.Length; i++)
        {
            knifes[i].sprite = knifeSprites[difficult];
            axes[i].sprite = axeSprites[difficult];
        }

        for (int i = 0; i < fires.Length; i++)
        {
            fires[i].runtimeAnimatorController = fireAnimators[difficult];
            coins[i].sprite = coinSprites[difficult];
        }
    }
}
