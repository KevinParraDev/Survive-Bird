using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireController : MonoBehaviour
{
    [SerializeField]
    private PolygonCollider2D[] colliders;
    private int currentColliderIndex = 0;

    public AudioSource fireAudio;

    public bool inUse;
    public GameObject fire;

    public void SetColliderForSprite(int spriteNum)
    {
        colliders[currentColliderIndex].enabled = false;
        currentColliderIndex = spriteNum;
        colliders[currentColliderIndex].enabled = true;
    }

    private void OnEnable()
    {
        inUse = true;
        StartCoroutine(AlertTime());
    }

    IEnumerator AlertTime()
    {
        yield return new WaitForSeconds(1.5f);
        fireAudio.Play();
        GetComponent<Animator>().SetTrigger("BigFire");
        StartCoroutine(DeleteTime());
    }

    IEnumerator DeleteTime()
    {
        yield return new WaitForSeconds(1.5f);
        fire.transform.position = new Vector2(0, fire.transform.position.y);
        fire.SetActive(false);
        inUse = false;
    }
}
