using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

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
