using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ston : MonoBehaviour
{
    public Animator anim;
    public GameObject ef;
    public GameObject audio;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "DestrSt")
        {
            anim.SetTrigger("HIT");
            Destroy(gameObject, 0.5f);
            ef.SetActive(true);
            audio.SetActive(true);
        }
    }
}
