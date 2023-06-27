using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knife : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Limits")
        {
            if(gameObject.tag == "Knife")
                GetComponentInParent<KnifeController>().ResetKnife();
            if (gameObject.tag == "Axe")
                GetComponentInParent<AxeController>().ResetAxe();
        }
    }
}
