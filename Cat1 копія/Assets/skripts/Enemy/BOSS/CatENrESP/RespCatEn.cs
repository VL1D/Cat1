using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespCatEn : MonoBehaviour
{
    public GameObject CatEnemy;
    public Animator anim;

    private void OnTriggerEnter2D (Collider2D collision)
    {
        if(collision.tag == "DestrSt")
        {
            anim.SetTrigger("respDell");
        }
    }

    public void RD()
    {
        Instantiate(CatEnemy, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
