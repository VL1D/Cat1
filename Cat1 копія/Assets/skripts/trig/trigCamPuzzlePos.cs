using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trigCamPuzzlePos : MonoBehaviour
{
    public GameObject Cam;

    public Transform PoinsCamPos;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            Cam.transform.position = PoinsCamPos.position;
        }
    }
}
