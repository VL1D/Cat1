using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WolfController : MonoBehaviour
{
    public float speed;
    public float JumpForse;

    public Rigidbody2D rb;
    public Animator anim;

    public Transform player;

    public bool Ground;
    public bool GroundDop;
    public Transform PointsGr;
    public Transform PointsGrDop;
    public LayerMask whatIsGround;
    public float checkRadius;

    public bool Atack;
    public bool Jump;
    public bool JumpDop;
    public bool CatClose;

    public GameObject audio;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        CheckColision();
        Move();
        Jumping();
        if(speed != 0)
        {
            anim.SetBool("RunWolf", true);
        }
        else
        {
            anim.SetBool("RunWolf", false);
        }

        if (!Ground)
        {
            anim.SetBool("jump", true);
        }
        else
        {
            anim.SetBool("jump", false);
        }
    }

    private void Move()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.position, Time.deltaTime * speed);
        if (transform.position.x < player.position.x)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        else if(transform.position.x > player.position.x)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
    }
    public void StopHunding()
    {
        speed = 0;
        anim.SetBool("RunWolf", false);
    }

    private void CheckColision()
    {
        Ground = Physics2D.OverlapCircle(PointsGr.position, checkRadius, whatIsGround);
        GroundDop = Physics2D.OverlapCircle(PointsGrDop.position, checkRadius, whatIsGround);
    }

    private void Jumping()
    {
        if (!CatClose)
        {
            if (!Ground && Jump || GroundDop && !JumpDop)
            {
                rb.velocity = Vector2.up * JumpForse;
            }
        }
    }

    public void AnAud()
    {
        audio.SetActive(true);
    }
}