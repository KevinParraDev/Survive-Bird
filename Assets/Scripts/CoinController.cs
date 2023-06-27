using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour
{
    public bool inUse;
    private void OnEnable()
    {
        inUse = true;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Limits")
        {
            ResetCoin();
        }
    }

    public void ResetCoin()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        transform.position = new Vector2(0, 6);
        this.gameObject.SetActive(false);
        inUse = false;
    }
}
