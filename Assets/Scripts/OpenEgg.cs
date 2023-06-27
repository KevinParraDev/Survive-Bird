using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenEgg : MonoBehaviour
{
    public Coins coins;
    public GameObject bird;
    public Animator eggAnim;
    void Start()
    {
        
    }

    public void Open()
    {
        if (PlayerPrefs.GetInt("coinsKey") >= 10)
        {
            coins.GetCoin(-1);
            eggAnim.SetTrigger("Open");
        }
        else
        {
            Debug.Log("No tienes monedas suficientes");
        }
    }

    public void ShowBird()
    {
        bird.SetActive(true);
    }
}
