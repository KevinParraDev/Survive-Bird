using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour
{
    public AudioSource buttonClip;
    Color green = new Color(0.1556604f,1,0.2828914f);
    Color white = new Color(1, 1, 1);
    public Image[] circles;
    public GameObject leftArrow;
    public GameObject tabBar;
    public GameObject[] buttons;
    public Animator tutorialAnim;
    public Text descriptionTxt;
    public Text infoButtonsTxt;
    public Text finishTxt;
    private int showTutorial;
    int language;
    int tabNumber;

    private string[][] textAR;
    private string[] esText = new string[] {"Toca el lado derecho de la pantalla para saltar a esa dirección", "Toca el lado izquierdo de la pantalla para saltar a esa dirección" , "Consigue monedas y desbloquea nuevas aves",
                                            "Cuando consigas 100 monedas, pulsa este botón para desbloquear una nueva ave", "Pulsa este botón para poder elegir el ave que quieras" , "Y por último, cuando te sientas listo pulsa este botón y te llevará a un mundo donde la dificultad aumentará",
                                            "Gracias por descargar Survive Bird, espero disfrutes del juego <3"};
    private string[] enText = new string[] { "Touch the right side of the screen to jump to that direction", "Touch the left side of the screen to jump to that direction", "Get coins and unlock new birds" ,
                                            "When you get 100 coins, press this button to unlock a new bird", "Press this button to choose the bird you want" , "And finally, when you feel ready press this button, and it will take you to a world where the difficulty will increase",
                                            "Thank you for downloading Survive Bird, I hope you enjoy the game <3"};

    public void VerifyShowTutorial(int lang)
    {
        bool result = PlayerPrefs.HasKey("tutorialKey");
        if (result)
            showTutorial = PlayerPrefs.GetInt("tutorialKey");
        else
        {
            showTutorial = 1;
        }

        Debug.Log("Show tutorial: "+showTutorial);

        ActualizeShowTutorial();

        if (showTutorial == 1)
            StartTutorial(lang);
        else if (showTutorial == 0)
            Close();
    }

    void ActualizeShowTutorial()
    {
        PlayerPrefs.SetInt("tutorialKey", showTutorial);
    }

    public void TutorialFinish()
    {
        showTutorial = 0;
        ActualizeShowTutorial();
    }

    public void StartTutorial(int lang)
    {
        language = lang;
        tabNumber = 0;
        textAR = new string[2][];

        textAR[0] = esText;
        textAR[1] = enText;

        descriptionTxt.text = textAR[language][0];
        if (language == 0)
        {
            finishTxt.text = "Terminar";
        }
        else if (language == 1)
        {
            finishTxt.text = "Finish";
        }
        SetTab(0);
    }

    public void NextTab(int direction)
    {
        if((tabNumber+direction) <= 7 & (tabNumber + direction) >= 0)
        {
            Debug.Log("NextTab: " + (tabNumber + direction));
            SetTab((tabNumber + direction));
        }
    }

    public void SetTab(int i)
    {
        tabNumber = i;
        buttonClip.Play();
        Debug.Log("SetTab: " + tabNumber);
        ResetCircles();
        if(tabNumber <=5)
            circles[tabNumber].color = green;

        if (tabNumber == 3 ^ tabNumber == 4 ^ tabNumber == 5)
        {
            leftArrow.SetActive(true);
            tabBar.SetActive(true);
            tutorialAnim.gameObject.SetActive(false);
            descriptionTxt.gameObject.SetActive(false);
            infoButtonsTxt.gameObject.SetActive(true);
            finishTxt.gameObject.SetActive(false);
        }
        else if (tabNumber == 0)
        {
            leftArrow.SetActive(false);
            tabBar.SetActive(true);
            tutorialAnim.gameObject.SetActive(true);
            descriptionTxt.gameObject.SetActive(true);
            infoButtonsTxt.gameObject.SetActive(false);
            finishTxt.gameObject.SetActive(false);
        }
        else if(tabNumber == 1 ^ tabNumber == 2)
        {
            leftArrow.SetActive(true);
            tabBar.SetActive(true);
            tutorialAnim.gameObject.SetActive(true);
            descriptionTxt.gameObject.SetActive(true);
            infoButtonsTxt.gameObject.SetActive(false);
            finishTxt.gameObject.SetActive(false);
        }
        else if(tabNumber == 6)
        {
            tutorialAnim.gameObject.SetActive(false);
            descriptionTxt.gameObject.SetActive(false);
            infoButtonsTxt.gameObject.SetActive(true);
            finishTxt.gameObject.SetActive(true);
        }

        if (tabNumber == 0)
        {
            tutorialAnim.SetTrigger("Right");
            descriptionTxt.text = textAR[language][0];
        }
        else if (tabNumber == 1)
        {
            tutorialAnim.SetTrigger("Left");
            descriptionTxt.text = textAR[language][1];
        }
        else if (tabNumber == 2)
        {
            tutorialAnim.SetTrigger("Egg");
            descriptionTxt.text = textAR[language][2];
        }
        else if (tabNumber == 3)
        {
            infoButtonsTxt.text = textAR[language][3];
            buttons[0].SetActive(true);
        }
        else if (tabNumber == 4)
        {
            infoButtonsTxt.text = textAR[language][4];
            buttons[1].SetActive(true);
        }
        else if (tabNumber == 5)
        {
            infoButtonsTxt.text = textAR[language][5];
            buttons[2].SetActive(true);

        }
        else if (tabNumber == 6)
        {
            infoButtonsTxt.text = textAR[language][6];
            finishTxt.gameObject.SetActive(true);
            tabBar.SetActive(false);
        }
        else if (tabNumber == 7)
            Close();
    }

    void ResetCircles()
    {
        for(int i = 0; i < circles.Length; i++)
        {
            circles[i].color = white;
        }
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].SetActive(false);
        }
    }

    void Close()
    {
        TutorialFinish();
        Destroy(this.gameObject);
    }
}
