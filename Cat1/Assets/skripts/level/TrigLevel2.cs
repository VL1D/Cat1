using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrigLevel2 : MonoBehaviour
{
    public PlayerController playerController;
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            Destroy(playerController.Level[1]);
        }
    }
}
