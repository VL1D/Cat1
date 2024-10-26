using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelRespavnFive : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && LEVBOOL.ent == false)
        {
            LevelManager.instance.RespawnLevel5();
            LEVBOOL.ent = true;
        }
    }
}
