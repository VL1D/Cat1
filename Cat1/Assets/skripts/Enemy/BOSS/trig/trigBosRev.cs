using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trigBosRev : MonoBehaviour
{
    public int i = 0;
    public BossController Bos;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Bos")
        {
            Bos.speed = 0;
            Bos.anim.SetTrigger("turnRL");
            Bos.anim.SetBool("runR", false);
            Bos.turn_RL = true;
            Bos.MR = false;
            i++;
            Bos.audio[0].SetActive(false);

        }
    }
}
