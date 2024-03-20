using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrigPlatformUpDown : MonoBehaviour
{
    public PlatformUpDown PlatformSkripts;
    public GameObject CollStopCat;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.tag == "Player" && PlatformSkripts.PlatformMove)
        {
            CollStopCat.SetActive(true);
        }
        else if (collision.tag == "Player" && !PlatformSkripts.PlatformMove)
        {
            CollStopCat.SetActive(false);
        }
    }
}
