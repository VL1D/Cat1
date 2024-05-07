using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrigNoJump : MonoBehaviour
{
    public Skuiller SK;
    public Animator anim;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "skuiller")
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
        yield return new WaitForSeconds(0.2f);
        SK.speed = 35f;
        SK.Run = true;
        anim.SetBool("Run", true);

    }
}
