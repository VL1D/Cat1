using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelEndTwo : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D colision)
    {
        if (colision.tag == "Player")
        {
            LevelManager.instance.RespawnLevel1();
        }
    }

}
