using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelRespawnThree : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            LevelManager.instance.RespawnLevel3();
        }
    }
}
