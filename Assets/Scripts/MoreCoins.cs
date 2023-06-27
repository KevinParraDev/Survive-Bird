using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoreCoins : MonoBehaviour
{
    public Coins coins;
    public void HideObject()
    {
        this.gameObject.SetActive(false);
    }

    public void GetCoins()
    {
        coins.GetCoin(30);
    }
}
