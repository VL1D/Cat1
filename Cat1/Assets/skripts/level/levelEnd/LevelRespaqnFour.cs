using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelRespaqnFour : MonoBehaviour
{
    public BoxCollider2D trigPlayer;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            trigPlayer.enabled = false;
        }
        if (collision.tag == "Player" && LEVBOOL.ent == false)
        {
            LevelManager.instance.RespawnLevel4();
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
