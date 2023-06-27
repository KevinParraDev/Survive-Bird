using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBirdAndStartButtom : MonoBehaviour
{
    public bool move;
    public bool canPlay;
    void Start()
    {
        move = false;
    }

    void Update()
    {
        if(move)
        {
            transform.Translate(-10f * Time.deltaTime, 0, 0);
            if(transform.position.x < 0.1f & this.name == "B-Play")
            {
                move = false;
                transform.position = new Vector2(0, transform.position.y);
            }
            else if (transform.position.x < -0.44f & this.name == "Bird")
            {
                move = false;
                transform.position = new Vector2(-0.34f, transform.position.y);
            }
        }
    }
}
