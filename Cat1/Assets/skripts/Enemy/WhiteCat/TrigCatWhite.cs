using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrigCatWhite : MonoBehaviour
{
    public ControllerCatEnemy EnemyCat;

    private void OnTriggerStay2D (Collider2D collision)
    {
        if(collision.tag == "Player")
        {
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
        }
    }
}
