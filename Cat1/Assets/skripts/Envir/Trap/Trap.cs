using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    public GameObject trigResp;
    public Animator anim;
    BoxCollider2D box;
    public GameObject coll;

    private void Start()
    {
        box = GetComponent<BoxCollider2D>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player" )
        {
            if (!trigResp.activeSelf)
            {
                trigResp.SetActive(true);
                anim.SetTrigger("Close");
                coll.SetActive(true);
            }
        }
        if ( collision.tag == "skuiller")
        {
            trigResp.SetActive(true);
            anim.SetTrigger("Close");
        }
    }

    public void AnimClos()
    {
        trigResp.SetActive(false);
        box.enabled = false;
    }
}