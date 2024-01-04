using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrigHangSkel : MonoBehaviour
{
    private Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Enemy" || other.tag == "Player")
        {
            anim.SetBool("isReel", true);
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Enemy" || other.tag == "Player")
        {
            anim.SetBool("isReel", false);
        }
    }
}
