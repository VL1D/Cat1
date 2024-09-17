using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerEnemyWater : MonoBehaviour
{
    public PlayerController playerController;

    public float speed;

    private Animator anim;
    private Rigidbody2D rb;

    public Transform CatPos;
    public GameObject AudioAtack;

    private void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        if (playerController.isWater)
        {
            StartHunting();
        }
        else
        {
            StoptHunting();
        }
        
    }

    private void StartHunting()
    {
        if(CatPos.position.x < transform.position.x)
        {
            rb.velocity = new Vector2 (-speed, 0);
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
        else if (CatPos.position.x > transform.position.x)
        {
            rb.velocity = new Vector2(speed, 0);
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        if (speed == 0)
        {
            anim.SetBool("Run", false);
        }
        else
        {

            anim.SetBool("Run", true);
        }
    }
    private void StoptHunting()
    {
        rb.velocity = Vector2.zero;
        anim.SetBool("Run", false);
    }

    public void AudAct()
    {
        //AudioAtack.SetActive(true);
    }
}
