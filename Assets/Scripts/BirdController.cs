using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdController : MonoBehaviour
{
    public AudioSource jumpSound;
    public AudioSource coinSound;
    public AudioSource hitSound;
    public AudioSource buttonSound;

    public GameObject[] firstTouchGO;
    public GameObject[] touchGO;

    public Animator anim;
    public Rigidbody2D birdRB;
    public ButtonsController buttonsController;
    public TimeController timeController;
    public DificultController dificultController;
    public ObstacleGenerator obstacleGenerator;
    public Coins coins;
    public Score score;
    public float XVelocity;
    public float YVelocity;
    public bool firtsTouch;
    public bool liveBird;
    public bool canTouch;
    void Start()
    {
        canTouch = true;
        firtsTouch = true;
        liveBird = true;

        EnableTouch(true, false);
    }


    /*private void OnBecameInvisible()
    {
        Debug.Log("Invisible " + (-this.transform.position.x) + this.transform.position.y);
        this.transform.position = new Vector2(-this.transform.position.x, this.transform.position.y);
    }

    private void OnBecameVisible()
    {
        Debug.Log("visible");
    }*/

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Coin")
        {
            coinSound.Play();
            coins.GetCoin(1);
            collision.GetComponent<CoinController>().ResetCoin();
        }

        if (collision.gameObject.name == "Limits")
        {
            ResetBird();
        }

        if (collision.gameObject.tag == "Fire")
        {
            DeathBird();
            anim.SetTrigger("Fired");
        }

        if (collision.gameObject.tag == "Knife" ^ collision.gameObject.tag == "Axe" ^ collision.gameObject.tag == "ClimbingPlant")
        {
            DeathBird();
            hitSound.Play();
            anim.SetTrigger("Explotion");
        }
    }

    public void ResetBird()
    {
        birdRB.isKinematic = true;
        birdRB.velocity = new Vector2(0, 0);
        birdRB.gameObject.transform.position = new Vector3(4.66f, 0.292f);
        anim.SetTrigger("Quiet");
    }

    void DeathBird()
    {
        Debug.Log("Muerteee!");
        score.NewScore(int.Parse(timeController.TimerControl));
        buttonsController.ShowTryAgainButtom();
        timeController.gameOver = true;
        dificultController.StopAllCoroutines();
        obstacleGenerator.ResetCoins();

        liveBird = false;
        GetComponent<CircleCollider2D>().enabled = false;
        buttonsController.isTryAgainButtom = true;
    }

    public void EnableTouch(bool a, bool e)
    {
        for (int i = 0; i <= 1; i++)
        {
            firstTouchGO[i].SetActive(a);
            touchGO[i].SetActive(e);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow) || (Input.GetKeyDown(KeyCode.A)))
            Touch("Leght");
        if (Input.GetKeyDown(KeyCode.RightArrow) || (Input.GetKeyDown(KeyCode.D)))
            Touch("Right");
    }

    public void Touch(string direction)
    {
        if (canTouch)
        {
            if (liveBird)
            {
                jumpSound.Play();

                if (buttonsController.pause == true)
                {
                    buttonsController.OpenWIndow("TouchForContinue");
                    buttonSound.Play();
                }

                if ((Input.GetKeyDown(KeyCode.W) ^ (direction == "Right") ^ direction == "Leght") & firtsTouch == true)
                {
                    Debug.Log("FirstTouch");
                    EnableTouch(false, true);
                    buttonSound.Play();
                    firtsTouch = false;
                    birdRB.GetComponent<CircleCollider2D>().enabled = true;
                    buttonsController.PressStartButtom();
                }

                if (Input.GetKeyDown(KeyCode.W))
                {
                    birdRB.velocity = new Vector2(0, YVelocity);
                    anim.SetTrigger("Fly");
                }

                if (direction == "Leght")
                {
                    birdRB.velocity = new Vector2(-XVelocity, YVelocity);
                    anim.SetTrigger("Fly");
                }

                if (direction == "Right")
                {
                    birdRB.velocity = new Vector2(XVelocity, YVelocity);
                    anim.SetTrigger("Fly");
                }
            }
            else if ((Input.GetKeyDown(KeyCode.W) ^ (direction == "Right") ^ direction == "Leght") & liveBird == false)
            {
                Debug.Log("Ocultar!!");
                buttonSound.Play();
                buttonsController.PressStartButtom();
            }
        }
    }
}
