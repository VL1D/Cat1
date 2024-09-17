using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheWolf : MonoBehaviour
{
    public WolfController controller;
    public Animator Musik;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Wolf")
        {
            controller.StopHunding();
            Musik.SetBool("Active", false);
            Sound.instance.Ac();
        }
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Wolf")
        {
            controller.StopHunding();
            Musik.SetBool("Active", false);
            Sound.instance.Ac();
        }
    }
}
