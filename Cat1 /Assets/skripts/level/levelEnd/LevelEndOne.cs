using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelEndOne : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D colision)
    {
        if (colision.tag == "Player" && LEVBOOL.ent == false)
        {
            LevelManager.instance.RespawnLevel2();
            LEVBOOL.ent = true;
        }
    }
}
