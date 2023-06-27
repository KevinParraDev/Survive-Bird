using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DificultController : MonoBehaviour
{
    public ObstacleGenerator obstacleGenerator;


    public void SelectDifficult(int knifeT, int fireT, int axeT, int doubleFireT, int extraKnifes)
    {
        StopAllCoroutines();
        StartCoroutine(ExtraObtacle());

        if(PlayerPrefs.GetString("mapKey") == "GreenMap")
            StartCoroutine(CoinSpawn(10));
        else if(PlayerPrefs.GetString("mapKey") == "RedMap")
            StartCoroutine(CoinSpawn(7));

        if (knifeT != 0)
            StartCoroutine(KnifeSpawn(knifeT));
        if (fireT != 0)
            StartCoroutine(FireSpawn(fireT));
        if (axeT != 0)
            StartCoroutine(AxeSpawn(axeT));
        if (doubleFireT != 0)
            StartCoroutine(DoubleFireSpawn(doubleFireT));
        if (extraKnifes != 0)
            StartCoroutine(ExtraKnifesSpawn(extraKnifes));
    }

    IEnumerator ExtraObtacle()
    {
        yield return new WaitForSeconds(1);
        Debug.Log("Extra");
        obstacleGenerator.SelectKnife();
    }

        IEnumerator KnifeSpawn(int maxD)
    {
        int delay = Random.Range(maxD-3,maxD);
        int randomAmount = Random.Range(0, 11);
        yield return new WaitForSeconds(delay);

        if(randomAmount == 10)
        {
            obstacleGenerator.SelectKnife();
            Debug.Log("Doble!");
            yield return new WaitForSeconds(0.7f);
            obstacleGenerator.SelectKnife();
        }
        else
            obstacleGenerator.SelectKnife();

        StartCoroutine(KnifeSpawn(maxD));
    }

    IEnumerator ExtraKnifesSpawn(int maxD)
    {
        int delay = Random.Range(maxD - 2, maxD);
        yield return new WaitForSeconds(delay);

        obstacleGenerator.SelectExtraKnifes();
        StartCoroutine(ExtraKnifesSpawn(maxD));
    }

    IEnumerator FireSpawn(int maxD)
    {
        int delay = Random.Range(maxD-3, maxD);
        yield return new WaitForSeconds(delay);
        
        obstacleGenerator.SelectFire();
        StartCoroutine(FireSpawn(maxD));
    }

    IEnumerator DoubleFireSpawn(int maxD)
    {
        int delay = Random.Range(maxD - 2, maxD);
        yield return new WaitForSeconds(delay);

        obstacleGenerator.SelectDoubleFire();
        StartCoroutine(DoubleFireSpawn(maxD));
    }

    IEnumerator AxeSpawn(int maxD)
    {
        int delay = Random.Range(maxD-3, maxD);
        int randomAmount = Random.Range(0, 11);
        yield return new WaitForSeconds(delay);

        if (randomAmount == 10)
        {
            obstacleGenerator.SelectAxe();
            yield return new WaitForSeconds(1);
            obstacleGenerator.SelectAxe();
        }
        else
            obstacleGenerator.SelectAxe();

        StartCoroutine(AxeSpawn(maxD));
    }

    IEnumerator CoinSpawn(int maxD)
    {
        int delay = Random.Range(maxD - 3, maxD);
        yield return new WaitForSeconds(delay);

        obstacleGenerator.SelectCoin();
        StartCoroutine(CoinSpawn(maxD));
    }
}
