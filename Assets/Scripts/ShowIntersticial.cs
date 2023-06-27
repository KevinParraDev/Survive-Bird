using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowIntersticial : MonoBehaviour
{
    private bool canShowIntersticial;
    public AdsManager adsManager;

    void Start()
    {
        canShowIntersticial=true;
    }

    public void EnableIntersticialPanel()
    {
        if(canShowIntersticial)
        {
            Debug.Log("Entró al intersticial");
            adsManager.ShowIntersticial();
        }
        else
        {
            Debug.Log("Aun no ha transcurrido el tiempo");
        }
    }

    public void EndInterstitial()
    {
        canShowIntersticial=false;
        StartCoroutine(LoadIntersticial());
    }

    IEnumerator LoadIntersticial()
    {
        yield return new WaitForSecondsRealtime(40);
        canShowIntersticial=true;
    }
}
