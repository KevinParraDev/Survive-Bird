using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleGenerator : MonoBehaviour
{
    public GameObject bird;
    public GameObject[] knifes;
    public GameObject[] fires;
    public GameObject[] axes;
    public GameObject[] coins;

    //---------------------------    Knife   --------------------------------
    void GenerateKnife(GameObject knifeForUse)
    {
        float error = Random.Range(-1.5f, 1.5f);
        Vector2 birdPosition = bird.transform.position;

        knifeForUse.SetActive(true);
        knifeForUse.transform.position = new Vector2(0, birdPosition.y + error - 0.36f);
    }

    public void SelectKnife()
    {
        GameObject knifeForUse = knifes[Random.Range(0, knifes.Length)];

        if (knifeForUse.GetComponent<KnifeController>().inUse == false)
            GenerateKnife(knifeForUse);
        else
            SelectKnife();
    }

    public void SelectExtraKnifes()
    {
        if (knifes[0].GetComponent<KnifeController>().inUse == false)
        {
            GenerateKnife(knifes[0]);
            GenerateKnife(knifes[1]);
            GenerateKnife(knifes[2]);
            GenerateKnife(knifes[3]);
            GenerateKnife(knifes[4]);
        }
        else
        {
            GenerateKnife(knifes[5]);
            GenerateKnife(knifes[6]);
            GenerateKnife(knifes[7]);
            GenerateKnife(knifes[8]);
            GenerateKnife(knifes[9]);
        }
    }

    //---------------------------    Fire   --------------------------------

    void GenerateFire(GameObject fireForUse)
    {
        float error = Random.Range(-1f, 1f);
        Vector2 birdPosition = bird.transform.position;

        fireForUse.SetActive(true);
        fireForUse.transform.position = new Vector2(birdPosition.x + error + 0.34f, fireForUse.transform.position.y);
    }

    public void SelectFire()
    {
        GameObject fireForUse = fires[Random.Range(0, fires.Length)];

        if (fireForUse.GetComponent<FireController>().inUse == false)
            GenerateFire(fireForUse);
        else
            SelectFire();
    }

    public void SelectDoubleFire()
    {
        if(fires[0].GetComponent<FireController>().inUse == false)
        {
            GenerateFire(fires[0]);
            GenerateFire(fires[1]);
        }
        else
        {
            GenerateFire(fires[2]);
            GenerateFire(fires[3]);
        }
    }

    //---------------------------    Axe   --------------------------------

    void GenerateAxe(GameObject axeForUse)
    {
        float error = Random.Range(-1f, 1f);
        Vector2 birdPosition = bird.transform.position;

        axeForUse.SetActive(true);
        axeForUse.transform.position = new Vector2(0, birdPosition.y + error - 0.36f);
    }

    public void SelectAxe()
    {
        GameObject AxeforUse = axes[Random.Range(0, axes.Length)];

        if (AxeforUse.GetComponent<AxeController>().inUse == false)
            GenerateAxe(AxeforUse);
        else
            SelectAxe();
    }

    //---------------------------    Coin   --------------------------------

    void GenerateCoin(GameObject coinForUse)
    {
        float error = Random.Range(-2f, 2f);

        coinForUse.SetActive(true);
        coinForUse.transform.position = new Vector2(error, coinForUse.transform.position.y);
    }

    public void SelectCoin()
    {
        GameObject coinForUse = coins[Random.Range(0, coins.Length)];

        if (coinForUse.GetComponent<CoinController>().inUse == false)
            GenerateCoin(coinForUse);
        else
            SelectCoin();
    }

    public void ResetCoins()
    {
        for(int i = 0; i < coins.Length; i++)
        {
            coins[i].GetComponent<CoinController>().ResetCoin();
        }
    }


    void Update()
    {
        if(Input.GetKeyDown(KeyCode.H))
            SelectKnife();

        if (Input.GetKeyDown(KeyCode.K))
            SelectFire();

        if (Input.GetKeyDown(KeyCode.J))
            SelectAxe();
    }
}
