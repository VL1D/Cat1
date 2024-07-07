using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrigCatWhite : MonoBehaviour
{
    public ControllerCatEnemy EnemyCat;
    public GameObject coll;

    private void OnTriggerStay2D (Collider2D collision)
    {
        if(collision.tag == "Player")
        {
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
}
