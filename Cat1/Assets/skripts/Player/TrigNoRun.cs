using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrigNoRun : MonoBehaviour
{
   public PlayerController controller;
    private BoxCollider2D box;

    private void Start()
    {
        box = GetComponent<BoxCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            controller.speed = 0f;
            box.enabled = false;
        }
    }
}
