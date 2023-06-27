using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxeController : MonoBehaviour
{
    public int direction;
    public GameObject axe;
    public GameObject alert;
    public AudioSource axeAudio;
    public bool inUse;

    private void OnEnable()
    {
        inUse = true;
        StartCoroutine(AlertTime());
    }

    IEnumerator AlertTime()
    {
        yield return new WaitForSeconds(1);
        axe.SetActive(true);
        alert.SetActive(false);
        axeAudio.Play();
        axe.GetComponent<Rigidbody2D>().isKinematic = false;
        axe.GetComponent<Rigidbody2D>().velocity = new Vector2(6 * direction, 6);
    }

    public void ResetAxe()
    {
        axe.GetComponent<Rigidbody2D>().isKinematic = true;
        axe.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        transform.position = new Vector2(0,0);
        axe.transform.position = new Vector2((-4) * direction, -1);
        axe.SetActive(false);
        alert.SetActive(true);
        this.gameObject.SetActive(false);
        inUse = false;
    }
}
