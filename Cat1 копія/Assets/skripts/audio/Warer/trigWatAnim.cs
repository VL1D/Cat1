using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trigWatAnim : MonoBehaviour
{
    public Animator anim;
    public GameObject AudioWat;

    private void OnTriggerEnter2D (Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            AudioWat.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            anim.SetBool("Act", true);
        }
    }
}
