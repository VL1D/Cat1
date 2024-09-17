using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrigCam : MonoBehaviour
{
    public GameObject[] Cam;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            Cam[0].gameObject.SetActive(false);
            Cam[1].gameObject.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Cam[1].gameObject.SetActive(false);
            Cam[0].gameObject.SetActive(true);
        }
    }
}
