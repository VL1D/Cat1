using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheWolf : MonoBehaviour
{
    public WolfController controller;
    public GameObject WolfAudio;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Wolf")
        {
            controller.StopHunding();
            WolfAudio.SetActive(false);
        }
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Wolf")
        {
            controller.StopHunding();
            WolfAudio.SetActive(false);
        }
    }
}
