using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonsController : MonoBehaviour
{
    public Rigidbody2D birdRB;
    public Rigidbody2D startButtomRB;

    public GameObject timeGO;
    public GameObject startPanelGO;
    public GameObject eggIcon;
    public GameObject[] musicButtomsGO;
    public GameObject[] soundButtomsGO;
    public GameObject blackCurtainGO;
    public GameObject pauseButtonGO;
    public GameObject descriptionGO;
    public GameObject habitatGO;

    public GameObject optionWindowGO;
    public GameObject selecBirdWindowGO;
    public GameObject creditsWindowGO;
    public GameObject pauseWindowGO;
    public GameObject touchForContinueGO;
    public GameObject aviaryWindowGO;
    public GameObject birdInformationWindowGO;

    public Animator tryAgainButtomAnim;
    public Animator timeAnim;
    public Animator newHighScoreAnim;

    public BirdController birdController;
    public TimeController timeController;
    public BirdsAnimations birdsAnimations;
    public Score score;
    public Coins coins;

    public AudioSource music;
    public AudioSource[] soundEfects;
    float[] soundEfectsVolume = new float[] {0.15f, 1, 0.3f, 0.15f, 0.3f,0.3f,0.3f,0.3f,0.5f,1,0.2f,0.5f};

    public Sprite[] musicIcon;
    public Sprite[] noMusicIcon;
    public Sprite noSoundIcon;
    public Sprite soundIcon;

    bool isStartButtom;
    public bool isTryAgainButtom;
    public bool pause;
    bool playMusic;
    bool sounds;

    void Start()
    {
        pause = false;
        sounds = true;
        playMusic = true;
        isStartButtom = true;
        isTryAgainButtom = false;
        birdRB.isKinematic = true;
        startButtomRB.isKinematic = true;

        if (coins.SeeCoins() > 99)
            eggIcon.SetActive(true);
        else
            eggIcon.SetActive(false);
    }

    public void ShowTryAgainButtom()
    {
        birdRB.GetComponent<CircleCollider2D>().enabled = false;
        tryAgainButtomAnim.SetTrigger("Show");
        timeAnim.SetTrigger("GameOver");
        pauseButtonGO.SetActive(false);

        birdController.canTouch = false;
        StartCoroutine(DelayForChangeButtoms(1));
    }

    public void HideTryAgainButtom()
    {
        timeAnim.SetTrigger("Reset");
        score.HideNewRecordTxt();
        birdController.ResetBird();
        tryAgainButtomAnim.SetTrigger("Hide");
        startPanelGO.SetActive(true);
        birdRB.GetComponent<MoveBirdAndStartButtom>().move = true;
        startButtomRB.GetComponent<MoveBirdAndStartButtom>().move = true;

        birdController.EnableTouch(true, false);
        birdController.firtsTouch = true;
        birdController.liveBird = true;

        birdController.canTouch = false;

        if(coins.SeeCoins() > 99)
            eggIcon.SetActive(true);
        else
            eggIcon.SetActive(false);

        //advertisingController.PutAd();
        //showIntersticial.EnableIntersticialPanel();

        StartCoroutine(DelayForChangeButtoms(0.5f));
    }

    public void PressStartButtom()
    {
        if (isStartButtom)
        {
            timeController.StartGame();
            birdRB.isKinematic = false;
            startButtomRB.isKinematic = false;
            startPanelGO.SetActive(false);
            pauseButtonGO.SetActive(true);
            timeGO.SetActive(true);

            isStartButtom = false;
        }

        if (isTryAgainButtom)
        {
            HideTryAgainButtom();

            isTryAgainButtom = false;
            isStartButtom = true;
        }
    }

    public void Music()
    {
        if (playMusic)
        {
            playMusic = false;
            musicButtomsGO[0].GetComponent<Image>().sprite = noMusicIcon[0];
            musicButtomsGO[1].GetComponent<Image>().sprite = noMusicIcon[1];
            musicButtomsGO[2].GetComponent<Image>().sprite = noMusicIcon[1];
            StartCoroutine(StopMusic());
        }
        else
        {
            music.UnPause();
            playMusic = true;
            musicButtomsGO[0].GetComponent<Image>().sprite = musicIcon[0];
            musicButtomsGO[1].GetComponent<Image>().sprite = musicIcon[1];
            musicButtomsGO[2].GetComponent<Image>().sprite = musicIcon[1];
            StartCoroutine(UnStopMusic());
        }
    }

    public void Sounds()
    {
        soundEfects[4].Play();

        if (sounds)
        {
            sounds = false;
            soundButtomsGO[0].GetComponent<Image>().sprite = noSoundIcon;
            soundButtomsGO[1].GetComponent<Image>().sprite = noSoundIcon;

            for (int i = 0; i < soundEfects.Length; i++)
            {
                soundEfects[i].volume = 0;
            }
        }
        else 
        {
            sounds = true;
            soundButtomsGO[0].GetComponent<Image>().sprite = soundIcon;
            soundButtomsGO[1].GetComponent<Image>().sprite = soundIcon;

            for (int i = 0; i < soundEfects.Length; i++)
            {
                soundEfects[i].volume = soundEfectsVolume[i];
            }
        }
    }

    public void OpenWIndow(string window)
    {
        CloseWindows();
        blackCurtainGO.SetActive(true);

        if (window == "Options")
        {
            optionWindowGO.SetActive(true);
        }
        else if (window == "SelectBird")
        {
            selecBirdWindowGO.SetActive(true);
            birdsAnimations.selectWindow = true;
        }
        else if (window == "Credits")
        {
            creditsWindowGO.SetActive(true);
        }
        else if (window == "Pause")
        {
            Time.timeScale = 0;
            pause = true;
            pauseWindowGO.SetActive(true);
        }
        else if (window == "Unpause")
        {
            blackCurtainGO.SetActive(false);
            pauseWindowGO.SetActive(false);
            touchForContinueGO.SetActive(true);
        }
        else if (window == "TouchForContinue")
        {
            blackCurtainGO.SetActive(false);
            Time.timeScale = 1;
            pause = false;
            touchForContinueGO.SetActive(false);
        }
        else if (window == "Aviary")
        {
            birdsAnimations.aviaryWindow = true;
            aviaryWindowGO.SetActive(true);
        }
        else if (window == "BirdInformation")
        {
            birdInformationWindowGO.SetActive(true);
        }
    }

    public void CloseWindows()
    {
        birdsAnimations.selectWindow = false;
        birdsAnimations.aviaryWindow = false;

        blackCurtainGO.SetActive(false);
        optionWindowGO.SetActive(false);
        selecBirdWindowGO.SetActive(false);
        creditsWindowGO.SetActive(false);
        aviaryWindowGO.SetActive(false);
        birdInformationWindowGO.SetActive(false);
    }

    public void ChangeBirdInformation(string info)
    {
        if(info=="Habitat")
        {
            descriptionGO.SetActive(false);
            habitatGO.SetActive(true);
        }
        else if(info=="Description")
        {
            descriptionGO.SetActive(true);
            habitatGO.SetActive(false);
        }
    }

    public IEnumerator DelayForChangeButtoms(float delay)
    {
        yield return new WaitForSeconds(delay);
        birdController.canTouch = true;
    }

    IEnumerator StopMusic()
    {
        yield return new WaitForEndOfFrame();
        if(music.volume > 0)
        {
            music.volume = music.volume - 0.01f;
            StartCoroutine(StopMusic());
        }
        else
        {
            music.Pause();
        }
    }

    IEnumerator UnStopMusic()
    {
        yield return new WaitForEndOfFrame();
        if (music.volume < 0.2)
        {
            music.volume = music.volume + 0.01f;
            StartCoroutine(UnStopMusic());
        }
    }
}
