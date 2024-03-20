using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverBlocGat : MonoBehaviour
{
    public Animator anim;
    public bool Blocking = false;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (!Blocking)
            {
                Blocking = true;
                anim.SetBool("Lever", true);

            }
            else
            {
                Blocking = false;
                anim.SetBool("Lever", false);
            }
        }
    }
}
