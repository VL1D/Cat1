using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trigWolf : MonoBehaviour
{
    public PlayerController controller;
    public WolfController wolfcontroller;
    public GameObject wolf;
    public Animator animWolf;
    public Animator Musick;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            controller.anim.SetBool("wolfAtack", true);
            controller.speed = 0;
            controller.jumpForce = 0;
            controller.WolfAt = true;
            wolf.SetActive(true);
            StartCoroutine(AnimSpeedWolf());
            CutsceneManager.Instance.StartCutscene("CatSceneWolf");
            StartCoroutine(SpeedWolf());
            Musick.SetBool("Active", true);
            Sound.instance.NoAc();
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            controller.speed = 0;
            controller.Run = false;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            controller.jumpForce = 35f;
        }
    }

    private IEnumerator AnimSpeedWolf()
    {
        yield return new WaitForSeconds(0.9f);
        animWolf.Play("hofl");

    }
    private IEnumerator SpeedWolf()
    {
        yield return new WaitForSeconds(2.5f);
        wolfcontroller.speed = 60;
        Destroy(gameObject);
        controller.WolfAt = true;

    }
}
