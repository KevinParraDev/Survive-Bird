using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeController : MonoBehaviour
{
    public AudioSource knifeAudio;
    public int direction;
    public GameObject knife;
    public GameObject alert;
    public bool inUse;

    private void OnEnable()
    {
        inUse = true;
        StartCoroutine(AlertTime());
    }

    IEnumerator AlertTime()
    {
        yield return new WaitForSeconds(1);
        knife.SetActive(true);
        alert.SetActive(false);
        knifeAudio.Play();
        knife.GetComponent<Rigidbody2D>().velocity = new Vector2(direction * 10, 0);
    }

    public void ResetKnife()
    {
        knife.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        knife.transform.position = new Vector2((-4) * direction, alert.transform.position.y);
        knife.SetActive(false);
        alert.SetActive(true);
        this.gameObject.SetActive(false);
        inUse = false;
    }
}
