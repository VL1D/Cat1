using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheWolf : MonoBehaviour
{
    public WolfController controller;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Wolf")
        {
            controller.StopHunding();
        }
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Wolf")
        {
            controller.StopHunding();
        }
    }
}
