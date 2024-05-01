using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ston : MonoBehaviour
{
    public Animator anim;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "DestrSt")
        {
            anim.SetTrigger("HIT");
            Destroy(gameObject, 0.5f);
        }
    }
}
