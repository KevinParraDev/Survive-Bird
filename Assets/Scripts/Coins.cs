using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Coins : MonoBehaviour
{
    public Text coinsTXT;
    public static int coins;

    void Start()
    {
        bool result = PlayerPrefs.HasKey("coinsKey");
        if (result)
            coins = PlayerPrefs.GetInt("coinsKey");
        else
            coins = 0;

        //coins = 500;

        ActualizeCoinsTxt();
    }

    void ActualizeCoinsTxt()
    {
        PlayerPrefs.SetInt("coinsKey", coins);

        coinsTXT.text = coins.ToString();
    }

    public void GetCoin(int i)
    {
        coins = coins + i;
        ActualizeCoinsTxt();
    }

    public int SeeCoins()
    {
        return coins;
    }
}
