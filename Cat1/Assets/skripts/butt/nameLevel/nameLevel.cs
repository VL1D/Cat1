using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nameLevel : MonoBehaviour
{
    public Animator ANIM;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            ANIM.SetTrigger("dell");
        }
    }
}
