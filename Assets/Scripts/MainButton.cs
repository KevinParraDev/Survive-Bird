using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainButton : MonoBehaviour
{
    public void StopAnimation()
    {
        GetComponent<Animator>().enabled = false;
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "LimitForStartButtom")
        {
            Debug.Log("Errroooorororororoo");
            gameObject.GetComponent<Rigidbody2D>().isKinematic = true;
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0,0);
            transform.position = new Vector2(5,-1.69f);
        }
    }

}
