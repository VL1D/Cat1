using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelRespavnFive : MonoBehaviour
{
    public BoxCollider2D trigPlayer;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            LevelManager.instance.RespawnLevel5();
            trigPlayer.enabled = true;
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
