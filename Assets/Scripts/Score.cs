using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text highScoreEasyTXT;
    public Text highScoreHardTXT;
    public static int highScoreEasy;
    public static int highScoreHard;
    public Animator newRecordAnim;
    bool newScore;

    void Start()
    {
        bool resultEasy = PlayerPrefs.HasKey("highScoreEasyKey");
        if (resultEasy)
            highScoreEasy = PlayerPrefs.GetInt("highScoreEasyKey");
        else
            highScoreEasy = 0;

        bool resultHard = PlayerPrefs.HasKey("highScoreHardKey");
        if (resultHard)
            highScoreHard = PlayerPrefs.GetInt("highScoreHardKey");
        else
            highScoreHard = 0;

        ActualizeScoreEasyTxt();
        ActualizeScoreHardTxt();
    }

    void ActualizeScoreEasyTxt()
    {
        PlayerPrefs.SetInt("highScoreEasyKey", highScoreEasy);
        highScoreEasyTXT.text = highScoreEasy.ToString();
    }

    void ActualizeScoreHardTxt()
    {
        PlayerPrefs.SetInt("highScoreHardKey", highScoreHard);
        highScoreHardTXT.text = highScoreHard.ToString();
    }

    public void NewScore(int score)
    {
        if(PlayerPrefs.GetString("mapKey") == "GreenMap")
        {
            if (score > PlayerPrefs.GetInt("highScoreEasyKey"))
            {
                highScoreEasy = score;
                newScore = true;
                newRecordAnim.SetTrigger("Show");
                ActualizeScoreEasyTxt();
            }
        }
        else if (PlayerPrefs.GetString("mapKey") == "RedMap")
        {
            if (score > PlayerPrefs.GetInt("highScoreHardKey"))
            {
                highScoreHard = score;
                newScore = true;
                newRecordAnim.SetTrigger("Show");
                ActualizeScoreHardTxt();
            }
        }
    }

    public void HideNewRecordTxt()
    {
        if(newScore == true)
            newRecordAnim.SetTrigger("Hide");
        newScore = false;
    }
}
