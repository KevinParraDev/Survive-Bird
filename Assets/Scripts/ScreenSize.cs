using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenSize : MonoBehaviour
{
    public Camera cameraA;

    public GameObject cPlantL;
    public GameObject cPlantR;

    public GameObject birdGO;
    void Start()
    {
        OnDrawGizmosSelected();
    }

    void OnDrawGizmosSelected()
    {
        Vector3 p = cameraA.ViewportToWorldPoint(new Vector3(1, 1, cameraA.nearClipPlane));
        cPlantL.transform.position = new Vector2(-p.x, cPlantL.transform.position.y);
        cPlantR.transform.position = new Vector2(p.x, cPlantR.transform.position.y);
    }
}
