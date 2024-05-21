using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrigSpawnR : MonoBehaviour
{
    public BossController Boss;
    public Animator animBoss;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Bos")
        {
            if (!Boss.End)
            {
                Boss.StartAnimSR();
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Bos")
        {
            animBoss.SetTrigger("SpawnR");
            gameObject.SetActive(false);
        }
    }
}
