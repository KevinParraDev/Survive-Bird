using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeScene : MonoBehaviour
{
    public GameObject buttoms;
    public GameObject obstacles;
    public GameObject bird;
    public GameObject ui;

    public GameObject backToGameButtom;
    public GameObject eggScreen;
    public GameObject redMapIcon;
    public GameObject greenMapIcon;
    public GameObject scoreEasy;
    public GameObject scoreHard;

    public BirdsAnimations birdsAnimations;
    public Coins coins;

    public string newMap;
    public string lastMap;

    public ChangeDifficulty changeDifficulty;


    void Start()
    {
        bool result = PlayerPrefs.HasKey("mapKey");
        if (result)
            lastMap = PlayerPrefs.GetString("mapKey");
        else
            lastMap = "GreenMap";

        newMap = lastMap;

        if(lastMap == "GreenMap")
            changeDifficulty.ChangeSceneClouds(0);
        else if(lastMap == "RedMap")
            changeDifficulty.ChangeSceneClouds(2);

        ChangeToEggScreen();
        ActualizeMap();
    }

    void ActualizeMap()
    {
        PlayerPrefs.SetString("mapKey", newMap);
    }



    public void NewBirdButton()
    {
        if (PlayerPrefs.GetInt("coinsKey") >= 100 && birdsAnimations.parts.Length < birdsAnimations.birds.Length)
        {
            if(GetComponent<Animator>().enabled == false)
            {
                OpenClouds("Egg");
                coins.GetCoin(-100);
            }
        }
        else
            Debug.Log("NO TIENES MONEDAS SUFICIENTES");
    }

    public void OpenClouds(string m)
    {
        newMap = m;

        if (newMap == "GreenMap")
            changeDifficulty.ChangeSceneClouds(0);
        else if (newMap == "RedMap")
            changeDifficulty.ChangeSceneClouds(2);

        GetComponent<Animator>().enabled = true;
    }

    public void CloseClouds()
    {
        GetComponent<Animator>().enabled = false;
    }

    public void ChangeToEggScreen()
    {
        Debug.Log("scene: " + newMap);
        if (newMap == "Egg")
        {
            //changeDifficulty.Change(0);
            obstacles.SetActive(false);
            buttoms.SetActive(false);
            bird.SetActive(false);
            ui.SetActive(false);
            eggScreen.SetActive(true);
            backToGameButtom.SetActive(true);
            birdsAnimations.AddNewSkin();
        }
        else if (newMap == "GreenMap")
        {
            
            changeDifficulty.Change(0);
            obstacles.SetActive(true);
            buttoms.SetActive(true);
            bird.SetActive(true);
            ui.SetActive(true);
            eggScreen.SetActive(false);
            backToGameButtom.SetActive(false);
            greenMapIcon.SetActive(false);
            redMapIcon.SetActive(true);
            scoreHard.SetActive(false);
            scoreEasy.SetActive(true);
            lastMap = newMap;
            ActualizeMap();
        }
        else if (newMap == "RedMap")
        {
            changeDifficulty.Change(2);
            obstacles.SetActive(true);
            buttoms.SetActive(true);
            bird.SetActive(true);
            ui.SetActive(true);
            eggScreen.SetActive(false);
            backToGameButtom.SetActive(false);
            redMapIcon.SetActive(false);
            greenMapIcon.SetActive(true);
            scoreHard.SetActive(true);
            scoreEasy.SetActive(false);
            lastMap = newMap;
            ActualizeMap();
        }
        else if (newMap == "Back")
        {
            Debug.Log("LastMap: " + lastMap);
            newMap = lastMap;
            ChangeToEggScreen();
        }
    }
}
