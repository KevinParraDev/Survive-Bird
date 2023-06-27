using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggAnimatorTrigger : MonoBehaviour
{
    public ButtonsController buttonsController;
    public ChangeScene changeScene;
    public Animator buttonAnim;
    public AudioSource magicSound;
    public AudioSource popSound;
    public GameObject birdGO;
    public void ChangeToGameScene()
    {
        changeScene.OpenClouds("Back");
    }

    public void ShowBird(string i)
    {
        if (i == "yes")
            birdGO.SetActive(true);
        else if (i == "no")
            birdGO.SetActive(false);
    }

    public void PlaySound(string sound)
    {
        if (sound == "magic")
            magicSound.Play();
        else if (sound == "pop")
            popSound.Play();
    }
}
