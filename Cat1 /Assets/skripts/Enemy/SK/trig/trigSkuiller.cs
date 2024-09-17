using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trigSkuiller : MonoBehaviour
{
    public Skuiller SK;
    public Animator anim;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "skuiller")
        {
            SK.speed = 0f;
            SK.Run = false;
            SK.Jump = false;
            anim.SetBool("jump", false);

            StartCoroutine(JumpWolf());
        }

    }

    private IEnumerator JumpWolf()
    {
        yield return new WaitForSeconds(0.1f);
        SK.speed = 45f;
        SK.Jump = true;
        anim.SetBool("jump", true);

    }
}
