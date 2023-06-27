using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Languages : MonoBehaviour
{
    public Tutorial tutorial;
    public BirdsAnimations birdsAnimations;
    public Text[] wordsTxt;

    static string[] spanishWords = new string[] {"ES","OPCIONES","CREDITOS","Elegir", "CRÉDITOS", "DISEÑO Y PROGRAMACIÓN", "MÚSICA" , "Obra: Haz Que Pase" , "Música de https://www.fiftysounds.com/es/" , "Toca para continuar" , "PAUSA"};
    static string[] englishhWords = new string[] {"EN", "OPTIONS", "CREDITS", "Choose","CREDITS", "DESING AND PROGRAMMING" , "MUSIC" , "Track: Make It Happen", "Music by https://www.fiftysounds.com" , "Tap to continue" , "PAUSE"};
    string[][] languageWordsContainer = new string[][] { spanishWords, englishhWords};

    public static int language;     //0 = Español, 1 = Ingles
    
    void Start()
    {
        bool result = PlayerPrefs.HasKey("languageKey");
        if (result)
            language = PlayerPrefs.GetInt("languageKey");
        else
        {
            string lang = Application.systemLanguage.ToString();
            if (lang == "Spanish")
                language = 0;
            else if (lang == "English")
                language = 1;
            else
                language = 1;
        }

        Debug.Log(Application.systemLanguage.ToString() + ": " + language);

        ActualizeLanguageTxt();
        tutorial.VerifyShowTutorial(language);
    }

    void ActualizeLanguageTxt()
    {
        PlayerPrefs.SetInt("languageKey", language);

        birdsAnimations.ChangeNameBird();
        for (int i = 0; i < wordsTxt.Length; i++)
            wordsTxt[i].text = languageWordsContainer[language][i];
    }

    public void ChangeLanguage()
    {
        if (language == 0)
            language = 1;
        else if (language == 1)
            language = 0;
        else
            language = 1;

        ActualizeLanguageTxt();
    }
}
