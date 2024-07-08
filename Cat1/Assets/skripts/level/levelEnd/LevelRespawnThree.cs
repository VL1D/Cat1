using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelRespawnThree : MonoBehaviour
{
    public BoxCollider2D trigPlayer;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            LevelManager.instance.RespawnLevel3();
            trigPlayer.enabled = false;
        }
    }
    private void OnTriggerExit2D(Collider2D colision)
    {
        if (colision.tag == "Player")
        {
            trigPlayer.enabled = true;
        }
    }
}
