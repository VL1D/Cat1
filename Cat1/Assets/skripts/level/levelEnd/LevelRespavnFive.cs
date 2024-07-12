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
            trigPlayer.enabled = true;
        }
        if (collision.tag == "Player" && LEVBOOL.ent == false)
        {
            LevelManager.instance.RespawnLevel5();
            LEVBOOL.ent = true;
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
