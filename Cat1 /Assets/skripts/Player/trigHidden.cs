using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trigHidden : MonoBehaviour
{
   private PlayerController controller;

    private void Start()
    {
        controller = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

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
