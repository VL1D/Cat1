using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trigHidden : MonoBehaviour
{
   public PlayerController controller;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            controller.hidden = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            controller.hidden = false;
        }
    }
}
