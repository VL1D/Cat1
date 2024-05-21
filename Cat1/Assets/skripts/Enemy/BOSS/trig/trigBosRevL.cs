using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trigBosRevL : MonoBehaviour
{
    public int i = 0;
    public BossController Bos;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Bos")
        {
            Bos.speed = 0;
            Bos.anim.SetTrigger("turnLR");
            Bos.anim.SetBool("runL", false);
            Bos.turn_LR = true;
            Bos.LR = false;
            i++;
            if(i == 1)
            {
                Bos.End = true;
            }
        }
    }
}
