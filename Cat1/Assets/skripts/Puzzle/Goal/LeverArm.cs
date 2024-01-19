using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class LeverArm : MonoBehaviour
{
    public Animator anim;
    public Animator Gat;
    public bool Blocking;

    public Gates[] gates;

    private void FixedUpdate()
    {
        if (!Blocking)
        {

            anim.SetBool("Lever",false);
            Gat.SetBool("isOpen", true);
            Gat.SetBool("isClose", false);
        }
        else
        {
            anim.SetBool("Lever", true);
            Gat.SetBool("isOpen", false);
            Gat.SetBool("isClose", true);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            if (!Blocking)
            {
                Blocking = true;
                gates[0].speed = 8f;
                gates[1].speed = 8f;
                gates[0].Open = true;
                gates[1].Open = true;
            }
            else
            {
                Blocking = false;
                gates[0].speed = 4f;
                gates[1].speed = 4f;
                gates[0].Open = false;
                gates[1].Open = false;
            }
        }
    }
}
