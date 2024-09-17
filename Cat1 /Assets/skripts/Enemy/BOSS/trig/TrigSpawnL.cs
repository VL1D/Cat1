using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrigSpawnL : MonoBehaviour
{
    public BossController Boss;
    public Animator animBoss;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Bos")
        {
            StartCoroutine(NoAct());
        }
    }

    private void OnTriggerStay2D (Collider2D collision)
    {
        if(collision.tag == "Bos")
        {
            if (!Boss.End)
            {
                Boss.StartAnimSL();
            }
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
    private IEnumerator NoAct()
    {
        yield return new WaitForSeconds(1.4f);
        gameObject.SetActive(false);
    }
}
