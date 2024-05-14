using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class trigSpeedWolf : MonoBehaviour
{
    public WolfController wolfcontroller;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            wolfcontroller.speed = 30f;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            wolfcontroller.speed = 60f;
        }
    }
}
