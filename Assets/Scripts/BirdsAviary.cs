using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BirdsAviary : MonoBehaviour
{
    public Image[] nFirstBird;
    public Image[] nSecondtBird;
    int actual = 1;
    int nskin = 0;
    int pos1=0;
    int pos2=1;
    public BirdsAnimations birdsAnimations;
    public Animator firstBirdsAnim;
    public Animator secondBirdsAnim;

    public void Reset()
    {
        if(pos1==-1)
        {
            firstBirdsAnim.SetTrigger("LeftSave");
            secondBirdsAnim.SetTrigger("CenterSave");
        }
        else if(pos1==1)
        {
            firstBirdsAnim.SetTrigger("RightSave");
            secondBirdsAnim.SetTrigger("CenterSave");
        }
        else if(pos2==-1)
        {
            secondBirdsAnim.SetTrigger("LeftSave");
        }
    }

    public void SetSprites(int currentSprite)
    {
        if(actual==1)
        {
            for (int i = 0; i < nFirstBird.Length; i++)
            {
                Debug.Log("nskin1: "+nskin);
                if(i + nskin > 25)
                    nFirstBird[i].gameObject.SetActive(false);
                else
                {
                    nFirstBird[i].gameObject.SetActive(true);
                    nFirstBird[i].sprite = birdsAnimations.birds[i + nskin][currentSprite];
                    nFirstBird[i].name = (i+nskin).ToString();
                }
            }
        }
        else if (actual == -1)
        {
            for (int i = 0; i < nFirstBird.Length; i++)
            {
                Debug.Log("nskin2: "+nskin);
                if(i + nskin > 25)
                    nSecondtBird[i].gameObject.SetActive(false);
                else
                {
                    nSecondtBird[i].gameObject.SetActive(true);
                    nSecondtBird[i].sprite = birdsAnimations.birds[i + nskin][currentSprite];
                    nSecondtBird[i].name = (i+nskin).ToString();
                }
            }
        }

    }

    public void Move(int direction)
    {
        actual *= -1;

        if(pos1==0 & direction==1)
        {
            pos1=1;
            pos2=0;
        }
        else if(pos1==0 & direction==-1)
        {
            pos1=-1;
            pos2=0;
        }
        else if(pos2==0 & direction==1)
        {
            pos1=0;
            pos2=1;
        }
        else if(pos2==0 & direction==-1)
        {
            pos1=0;
            pos2=-1;
        }

        if(direction==-1)
        {
            firstBirdsAnim.SetTrigger("Left");
            secondBirdsAnim.SetTrigger("Left");
            if(nskin>=18)           //NOTA!! El 18 es porque hasta ahora con la cantidad de aves que hay, solo se pueden mostrar 27 casillas diferentes, el 18 es de 27-9
            {
                nskin=0;
                Debug.Log("Cambio"+(nskin));
            }
            else
                nskin += 9;
        }
        else if (direction == 1)
        {

            firstBirdsAnim.SetTrigger("Right");
            secondBirdsAnim.SetTrigger("Right");
            if(nskin-9<0)
                nskin=18;           //NOTA!! El 18 es porque hasta ahora con la cantidad de aves que hay, solo se pueden mostrar 27 casillas diferentes, el 18 es de 27-9
            else
                nskin -= 9;
        }
    }

    void Update()
    {
        
    }
}
