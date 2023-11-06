using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolfController : MonoBehaviour
{
    public float speed;
    public float JumpForse;
    public float checkRadius;

    public Rigidbody2D rb;
    public Animator anim;

    public Transform player;
    public Transform ground, groundCheck, groundDop;

    private bool isGroundCheck , isGround , isGroundDop;

    public LayerMask GrondLayer;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        Move();
        Jump();
    }

    private void Move()
    {
        StartHunting();
        if(speed == 0)
        {
            anim.SetBool("RunWolf", false);
        }
        else
        {
            anim.SetBool("RunWolf", true);
        }
    }

    private void StartHunting()
    {
        if(player.position.x < transform.position.x)
        {
            rb.velocity = new Vector2(-speed, 0);
        }
        else if(player.position.x > transform.position.x)
        {
            rb.velocity = new Vector2(speed, 0);
        }
    }


    private void Jump()
    {
        isGround = Physics2D.OverlapCircle(ground.position, checkRadius, GrondLayer);
        isGroundCheck = Physics2D.OverlapCircle(groundCheck.position, checkRadius, GrondLayer);
        isGroundDop = Physics2D.OverlapCircle(groundDop.position, checkRadius, GrondLayer);
        if (!isGroundDop )
        {
            rb.velocity = Vector2.up * JumpForse;
            StartCoroutine(JumpWolf());
            transform.position += transform.right * 0.85f;
        }
        else if (isGroundCheck)
        {
            rb.velocity = Vector2.up * JumpForse;
            StartCoroutine(JumpWolf());
            transform.position += transform.right * 0.85f;
        }
        else
        {
            Move();
        }
        if (!isGround)
        {
            anim.SetBool("jump", true);
        }
        else
        {
            anim.SetBool("jump", false);
            JumpForse = 85;
        }
    }

    private IEnumerator JumpWolf()
    {
        yield return new WaitForSeconds(0.5f);
        JumpForse = 0;

    }

}
