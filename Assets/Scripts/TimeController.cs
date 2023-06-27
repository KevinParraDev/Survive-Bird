using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeController : MonoBehaviour
{
    public string TimerControl;
    private float StartTime;
    public bool gameOver;
    public DificultController dificultController;
    public Score score;
    public Text highScoreEasyTXT;
    public Text highScoreHardTXT;

    bool callToChange;

    public void StartGame()
    {
        StartTime = Time.time;
        gameOver = false;
        callToChange = true;

        if (PlayerPrefs.GetString("mapKey") == "GreenMap")
            dificultController.SelectDifficult(6, 13, 0, 0, 0);
        else if (PlayerPrefs.GetString("mapKey") == "RedMap")
            dificultController.SelectDifficult(5, 13, 10, 0, 0);
    }

    public void HideScore()
    {
        this.gameObject.SetActive(false);
    }

    void Update()
    {
        if(gameOver == false)
        {
            if (PlayerPrefs.GetString("mapKey") == "GreenMap")
            {
                TimerControl = (Time.time - StartTime).ToString("f0");
                GetComponent<Text>().text = TimerControl;

                if (int.Parse(TimerControl) > PlayerPrefs.GetInt("highScoreEasyKey"))
                {
                    highScoreEasyTXT.text = TimerControl.ToString();
                }

                if (TimerControl == "20" & callToChange == true)    //20
                {
                    callToChange = false;
                    Debug.Log("Cambio de dificultad 1 f");
                    dificultController.SelectDifficult(6, 13, 10, 0, 0);
                }
                else if (TimerControl == "21" ^ TimerControl == "41" ^ TimerControl == "61" ^ TimerControl == "81" ^ TimerControl == "101" ^ TimerControl == "121" ^ TimerControl == "131" ^ TimerControl == "151" ^ TimerControl == "171" ^ TimerControl == "201" ^ TimerControl == "221" ^ TimerControl == "271" ^ TimerControl == "321" & callToChange == false)
                    callToChange = true;

                if (TimerControl == "40" & callToChange == true)    //20
                {
                    callToChange = false;
                    Debug.Log("Cambio de dificultad 2 f");
                    dificultController.SelectDifficult(6, 10, 8, 0, 0);
                }

                if (TimerControl == "60" & callToChange == true)    //20
                {
                    callToChange = false;
                    Debug.Log("Cambio de dificultad 3 f");
                    dificultController.SelectDifficult(5, 8, 8, 0, 0);
                }

                if (TimerControl == "80" & callToChange == true)    //20
                {
                    callToChange = false;
                    Debug.Log("Cambio de dificultad 4 f");
                    dificultController.SelectDifficult(5, 7, 7, 0, 0);
                }

                if (TimerControl == "100" & callToChange == true)    //20
                {
                    callToChange = false;
                    Debug.Log("Cambio de dificultad 5 f");
                    dificultController.SelectDifficult(5, 7, 5, 0, 0);
                }

                if (TimerControl == "120" & callToChange == true)    //20
                {
                    callToChange = false;
                    Debug.Log("Cambio de dificultad 6 f");
                    dificultController.SelectDifficult(0, 0, 0, 5, 0);
                }

                if (TimerControl == "130" & callToChange == true)    //20
                {
                    callToChange = false;
                    Debug.Log("Cambio de dificultad 7 f");
                    dificultController.SelectDifficult(6, 0, 0, 5, 0);
                }

                if (TimerControl == "150" & callToChange == true)    //20
                {
                    callToChange = false;
                    Debug.Log("Cambio de dificultad 8 f");
                    dificultController.SelectDifficult(0, 0, 6, 0, 5);
                }

                if (TimerControl == "170" & callToChange == true)    //20
                {
                    callToChange = false;
                    Debug.Log("Cambio de dificultad 7 f");
                    dificultController.SelectDifficult(5, 0, 0, 0, 4);
                }

                if (TimerControl == "200" & callToChange == true)    //20
                {
                    callToChange = false;
                    Debug.Log("Cambio de dificultad 8 f");
                    dificultController.SelectDifficult(0, 5, 5, 0, 3);
                }

                if (TimerControl == "220" & callToChange == true)     //70
                {
                    callToChange = false;
                    Debug.Log("Cambio de dificultad 3");
                    dificultController.SelectDifficult(4, 6, 5, 0, 0);
                }

                if (TimerControl == "270" & callToChange == true)    //20
                {
                    callToChange = false;
                    Debug.Log("Cambio de dificultad 7 f");
                    dificultController.SelectDifficult(5, 0, 0, 0, 4);
                }

                if (TimerControl == "320" & callToChange == true)    //20
                {
                    callToChange = false;
                    Debug.Log("Cambio de dificultad 8 f");
                    dificultController.SelectDifficult(0, 5, 5, 0, 3);
                }
            }

            else if (PlayerPrefs.GetString("mapKey") == "RedMap")
            {
                TimerControl = (Time.time - StartTime).ToString("f0");
                GetComponent<Text>().text = TimerControl;

                if (int.Parse(TimerControl) > PlayerPrefs.GetInt("highScoreHardKey"))
                {
                    highScoreHardTXT.text = TimerControl.ToString();
                }

                if (TimerControl == "10" & callToChange == true)    //20
                {
                    callToChange = false;
                    Debug.Log("Cambio de dificultad 1");
                    dificultController.SelectDifficult(5, 13, 7, 0, 0);
                }
                else if (TimerControl == "11" ^ TimerControl == "31" ^ TimerControl == "61" ^ TimerControl == "91" ^ TimerControl == "101" ^ TimerControl == "116" ^ TimerControl == "131" ^ TimerControl == "151" ^ TimerControl == "176" ^ TimerControl == "201" & callToChange == false)
                    callToChange = true;

                if (TimerControl == "30" & callToChange == true)    //40
                {
                    callToChange = false;
                    Debug.Log("Cambio de dificultad 2");
                    dificultController.SelectDifficult(4, 8, 5, 0, 0);
                }

                if (TimerControl == "60" & callToChange == true)     //70
                {
                    callToChange = false;
                    Debug.Log("Cambio de dificultad 3");
                    dificultController.SelectDifficult(4, 6, 5, 0, 0);
                }

                if (TimerControl == "90" & callToChange == true)
                {
                    callToChange = false;
                    Debug.Log("Cambio de dificultad 4");
                    dificultController.SelectDifficult(5, 0, 0, 4, 0);
                }

                if (TimerControl == "100" & callToChange == true)
                {
                    callToChange = false;
                    Debug.Log("Cambio de dificultad 5");
                    dificultController.SelectDifficult(4, 0, 0, 4, 0);
                }

                if (TimerControl == "115" & callToChange == true)
                {
                    callToChange = false;
                    Debug.Log("Cambio de dificultad 6");
                    dificultController.SelectDifficult(4, 0, 5, 4, 0);
                }

                if (TimerControl == "130" & callToChange == true)
                {
                    callToChange = false;
                    Debug.Log("Cambio de dificultad 7");
                    dificultController.SelectDifficult(0, 5, 0, 0, 3);
                }

                if (TimerControl == "150" & callToChange == true)
                {
                    callToChange = false;
                    Debug.Log("Cambio de dificultad 8");
                    dificultController.SelectDifficult(0, 5, 5, 0, 3);
                }

                if (TimerControl == "175" & callToChange == true)
                {
                    callToChange = false;
                    Debug.Log("Cambio de dificultad 9");
                    dificultController.SelectDifficult(4, 0, 5, 4, 0);
                }

                if (TimerControl == "200" & callToChange == true)
                {
                    callToChange = false;
                    Debug.Log("Cambio de dificultad 10");
                    dificultController.SelectDifficult(0, 5, 5, 0, 3);
                }
            }
        }
    }
}
