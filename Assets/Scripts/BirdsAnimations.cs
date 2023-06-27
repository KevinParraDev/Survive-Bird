using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BirdsAnimations : MonoBehaviour
{
    public int skin;
    int randomSkin;
    int sampleSkin;
    int samplePosSkinList;
    public bool selectWindow;
    public bool aviaryWindow;
    public BirdsAviary birdsAviary;

    public GameObject eggIcon;

    public SpriteRenderer birdEggSprite;
    public SpriteRenderer birdSprite;
    public Image birdImage;

    public Sprite[][] birds;

    public Sprite[] birdTucanPicoIris;
    public Sprite[] birdCacatua;
    public Sprite[] birdChorlitejo;
    public Sprite[] birdGallitoDeRoca;
    public Sprite[] birdGuacamayaMacao;
    public Sprite[] birdBarranqueroAndino;
    public Sprite[] birdCompas;
    public Sprite[] birdPichiCollarejo;
    public Sprite[] birdTangaraMulticolor;
    public Sprite[] birdToritoCabecirojo;
    public Sprite[] birdLoro;
    public Sprite[] birdGuacamayaAzul;
    public Sprite[] birdMosqueroCardenal;
    public Sprite[] birdBuhoCornudo;
    public Sprite[] birdBuhoEnmascarado;
    public Sprite[] birdBuhoNival;
    public Sprite[] birdCuervoComun;
    public Sprite[] birdReinitaCanadiense;
    public Sprite[] birdCardenillaCapirroja;
    public Sprite[] birdPlatanero;
    public Sprite[] birdPaloma;
    public Sprite[] birdPalomaBlanca;
    public Sprite[] birdTangaraAzuleja;
    public Sprite[] birdCharaAzul;
    public Sprite[] birdTucanToco;
    public Sprite[] birdTucanChoco;


    public Text birdNameTxt;
    public Text infoBirdNameTxt;
    private string[] birdNamesAR = new string[] { "Tucán Pico Iris","Chorlitejo","Cacatúa galerita","Gallito De Roca","Guacamaya Macao","Barranquero Andino","Compás","Pichí Collarejo","Tángara Multicolor"
                                                    ,"Torito Cabecirojo", "Loro real amazónico", "Guacamayo azul y amarillo", "Mosquero Cardenal", "Búho Cornudo", "Lechuza De Campanario" , "Búho Nival", "Cuervo Común" , "Reinita Canadiense"
                                                    ,"Cardenilla Capirroja" , "Platanero" , "Paloma" , "Paloma Blanca" , "Tangara Azuleja" , "Chara Azul" , "Tucán Toco" , "Tucán Del Chocó"};
    private string[] birdEnglishNamesAR = new string[] { "keel billed toucan","Kentish Plover","Sulphur crested cockatoo","Andean Cock Of The Rock","Scarlet Macaw","Andean Motmot","Toucan Barbet","Collared Aracari","Multicoloured Tanager"
                                                    ,"Red Headed Barbet", "Yellow crowned amazon", "Blue And Yellow Macaw", "Scarlet Flycatcher", "Great Horned Owl", "Western Barn Owl" , "Snowy Owl" , "Common Raven" , "Canada Warbler"
                                                    ,"Red Capped Cardinal" , "Bananaquit" , "Pigeon" , "White Pigeon" , "Blue Gray Tanager" , "Blue Jay" , "Toco Toucan" , "Choco Toucan"};

    private int currentSpriteIndex = 0;

    public string listOfBirds;
    public string[] parts;
    List<int> listOfPurchasedBirds = new List<int>();
    public int posSkinList;

    void ResetValues()
    {
        //listOfBirds = "0♣1♣2♣3♣4♣5♣6♣7♣8♣9♣10♣11♣12♣13♣14♣15♣16♣17♣18♣19♣20♣21♣22♣23♣24";
        listOfBirds = "0";
        posSkinList = 0;

        ActualizeSkin();
        ActualizeSkinList();
    }

    void Start()
    {
        //ResetValues();

        birds = new Sprite[26][];

        birds[0] = birdTucanPicoIris;
        birds[1] = birdChorlitejo;
        birds[2] = birdCacatua;
        birds[3] = birdGallitoDeRoca;
        birds[4] = birdGuacamayaMacao;
        birds[5] = birdBarranqueroAndino;
        birds[6] = birdCompas;
        birds[7] = birdPichiCollarejo;
        birds[8] = birdTangaraMulticolor;
        birds[9] = birdToritoCabecirojo;
        birds[10] = birdLoro;
        birds[11] = birdGuacamayaAzul;
        birds[12] = birdMosqueroCardenal;
        birds[13] = birdBuhoCornudo;
        birds[14] = birdBuhoEnmascarado;
        birds[15] = birdBuhoNival;
        birds[16] = birdCuervoComun;
        birds[17] = birdReinitaCanadiense;
        birds[18] = birdCardenillaCapirroja;
        birds[19] = birdPlatanero;
        birds[20] = birdPaloma;
        birds[21] = birdPalomaBlanca;
        birds[22] = birdTangaraAzuleja;
        birds[23] = birdCharaAzul;
        birds[24] = birdTucanToco;
        birds[25] = birdTucanChoco;

        //listOfBirds = "0♣1♣4";

        bool listBirdResult = PlayerPrefs.HasKey("listBirdKey");
        if (listBirdResult)
            listOfBirds = PlayerPrefs.GetString("listBirdKey");
        else
            listOfBirds = "0";

        UpdateAvalideBirds();

        bool result = PlayerPrefs.HasKey("posSkinListKey");
        if (result)
            posSkinList = PlayerPrefs.GetInt("posSkinListKey");
        else
            posSkinList = 0;

        skin = listOfPurchasedBirds[posSkinList];
        sampleSkin = skin;
        randomSkin = skin;
        samplePosSkinList = posSkinList;

        ActualizeSkin();
        birdNameTxt.text = birdNamesAR[skin];
        birdSprite.sprite = birds[skin][currentSpriteIndex];
        birdImage.sprite = birds[sampleSkin][currentSpriteIndex];
        ChangeNameBird();
        CheckIfCanBuy();
    }

    public void UpdateAvalideBirds()
    {
        listOfPurchasedBirds.Clear();
        parts = listOfBirds.Split('♣');

        for (int i = 0; i < parts.Length; i++)
        {
            listOfPurchasedBirds.Add(int.Parse(parts[i]));
        }
        CheckIfCanBuy();
    }

    public void CheckIfCanBuy()
    {
        Debug.Log("Check entró " + parts.Length + " - " + birds.Length);
        if (parts.Length == birds.Length)
        {
            eggIcon.SetActive(false);
            Debug.Log("Check se quitó");
        }
    }

    public void SetSprite(int spriteNum)
    {
        currentSpriteIndex = spriteNum;

        if (selectWindow)
            birdImage.sprite = birds[sampleSkin][currentSpriteIndex];
        else if(aviaryWindow)
        {
            Debug.Log("Aviariooo "+currentSpriteIndex);
            birdsAviary.SetSprites(currentSpriteIndex);
        }
        else
        {
            birdSprite.sprite = birds[skin][currentSpriteIndex];
            birdEggSprite.sprite = birds[randomSkin][currentSpriteIndex];
        }
    }

    public void MoveSkin(int direction)
    {
        if ((samplePosSkinList + direction) >= 0 & (samplePosSkinList + direction) <= (listOfPurchasedBirds.Count - 1))
        {
            samplePosSkinList = samplePosSkinList + direction;
            sampleSkin = listOfPurchasedBirds[samplePosSkinList];
            birdImage.sprite = birds[sampleSkin][currentSpriteIndex];
            birdImage.sprite = birds[sampleSkin][currentSpriteIndex];

            ChangeNameBird();
        }
        else if((samplePosSkinList + direction) >= listOfPurchasedBirds.Count)
        {
            samplePosSkinList = -1;
            MoveSkin(1);
        }
        else if ((samplePosSkinList + direction) < 0)
        {
            samplePosSkinList = listOfPurchasedBirds.Count;
            MoveSkin(-1);
        }
    }

    public void SelectSkin()
    {
        posSkinList = samplePosSkinList;
        skin = sampleSkin;
        ActualizeSkin();
        birdImage.sprite = birds[skin][currentSpriteIndex];
        birdSprite.sprite = birds[skin][currentSpriteIndex];
    }

    public void AddNewSkin()
    {
        int randomSkin = Random.Range(0, birds.Length);
        if (listOfPurchasedBirds.Contains(randomSkin))
        {
            Debug.Log("Oh no, ya tienes la skin " + randomSkin);
            AddNewSkin();
        }
        else
        {
            birdEggSprite.sprite = birds[randomSkin][currentSpriteIndex];
            listOfBirds = (listOfBirds + "♣" + randomSkin.ToString());
            Debug.Log("La skin " + randomSkin + "fue agregada, la nueva lista es: " + listOfBirds);
            ActualizeSkinList();
            UpdateAvalideBirds();
        }
    }

    public void ChangeNameBird()
    {
        if (PlayerPrefs.GetInt("languageKey") == 0)
            birdNameTxt.text = birdNamesAR[sampleSkin];
        else if (PlayerPrefs.GetInt("languageKey") == 1)
            birdNameTxt.text = birdEnglishNamesAR[sampleSkin];
    }

    public void ChangeInfoBirdName(int b)
    {
        if (PlayerPrefs.GetInt("languageKey") == 0)
            infoBirdNameTxt.text = birdNamesAR[b];
        else if (PlayerPrefs.GetInt("languageKey") == 1)
            infoBirdNameTxt.text = birdEnglishNamesAR[b];
    }

    public void Close()
    {
        if(skin != sampleSkin)
        {
            samplePosSkinList = posSkinList;
            sampleSkin = skin;
            birdImage.sprite = birds[skin][currentSpriteIndex];
            birdSprite.sprite = birds[skin][currentSpriteIndex];
        }
    }

    void ActualizeSkin()
    {
        PlayerPrefs.SetInt("posSkinListKey", posSkinList);
    }

    void ActualizeSkinList()
    {
        PlayerPrefs.SetString("listBirdKey", listOfBirds);
    }
}
