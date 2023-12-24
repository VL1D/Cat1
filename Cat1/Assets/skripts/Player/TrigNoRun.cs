using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrigNoRun : MonoBehaviour
{
   public PlayerController controller;

   
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            controller.speed = 0f;
            Destroy(gameObject);
        }
    }
}
