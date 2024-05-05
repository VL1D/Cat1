using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrigSpawnL : MonoBehaviour
{
    public BossController Boss;
    public Animator animBoss;

    private void OnTriggerStay2D (Collider2D collision)
    {
        if(collision.tag == "Bos")
        {
            Boss.StartAnimSL();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Bos")
        {
            animBoss.SetTrigger("SpawnL");
            gameObject.SetActive(false);
        }
    }
}
