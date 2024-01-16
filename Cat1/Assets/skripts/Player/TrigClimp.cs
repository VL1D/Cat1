using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TrigClimp : MonoBehaviour
{
    public PlayerController controller;
    BoxCollider2D box;

    private void Start()
    {
        controller = GetComponentInParent<PlayerController>();
        box = GetComponents<BoxCollider2D>()[0];
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == 7 || collision.gameObject.layer == 9 || collision.gameObject.layer == 13)
        {
            box.enabled = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 7 || collision.gameObject.layer == 9 || collision.gameObject.layer == 13)
        {
            box.enabled = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 7 || collision.gameObject.layer == 13)
        {
            controller.StartAnimLedge();
        }
        if(collision.gameObject.layer == 14)
        {
            box.enabled = false;
        }
    }
}
