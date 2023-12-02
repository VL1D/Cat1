using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trigWolf : MonoBehaviour
{
    public PlayerController controller;
    public WolfController wolfcontroller;
    public GameObject wolf;
    public Animator animWolf;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            controller.speed = 0;
            controller.jumpForce = 0;
            wolf.SetActive(true);
            StartCoroutine(AnimSpeedWolf());
            CutsceneManager.Instance.StartCutscene("CatSceneWolf");
            StartCoroutine(SpeedWolf());
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            controller.speed = 0;
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
        wolfcontroller.speed = 80;
        Destroy(gameObject);
    }
}
