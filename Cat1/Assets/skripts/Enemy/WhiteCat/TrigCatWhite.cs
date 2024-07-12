using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrigCatWhite : MonoBehaviour
{
    public ControllerCatEnemy EnemyCat;
    public GameObject coll;
    private BoxCollider2D trigPlayer;

    private void Start()
    {
        trigPlayer = GameObject.FindGameObjectWithTag("Player").GetComponent<BoxCollider2D>();

    }
    private void OnTriggerStay2D (Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            trigPlayer.enabled = false;
            coll.SetActive(true);
            if (!EnemyCat.StopAtackin)
            {
                if (!EnemyCat.Atack)
                {
                    EnemyCat.PrepAt = true;
                }
                else
                {
                    EnemyCat.PrepAt = false;
                }
            }
            if (EnemyCat.DeatchEN)
            {
                coll.SetActive(false);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            trigPlayer.enabled = true;
        }
    }
}
