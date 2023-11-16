using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WolfController : MonoBehaviour
{
    public float speed;
    public float JumpForse;
    public float checkRadius;
    public float CheckPlayer;

    public Rigidbody2D rb;
    public Animator anim;

    public Transform player;
    public Transform ground, groundCheck, groundDop, playerCheck;

    public bool  isGround  ;
    private bool isGroundCheck, isGroundDop;
    public bool PlayerCheck;

    public LayerMask GrondLayer;
    public LayerMask PlayerCheckLayer;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        Move();
        Jump();
        Check();
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
        if (isGround )
        {
            if(player.position.x < transform.position.x)
            {
               rb.velocity = new Vector2(-speed, 0);
                transform.eulerAngles = new Vector3(0, 180, 0);
            }
            else if(player.position.x > transform.position.x)
            {
                rb.velocity = new Vector2(speed, 0);
                transform.eulerAngles = new Vector3(0, 0, 0);
            }
        }
        else
        {
            transform.position += transform.right * 0.85f;
        }
    }


    private void Jump()
    {
        if (!isGroundDop )
        {
            rb.velocity = Vector2.up * JumpForse;
            StartCoroutine(JumpWolf());
        }
        else if (isGroundCheck)
        {
            if (!PlayerCheck)
            {
                rb.velocity = Vector2.up * JumpForse;
                StartCoroutine(JumpWolf());
            }
            else
            {
                Move();
            }
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

    private void Check()
    {
        isGround = Physics2D.OverlapCircle(ground.position, checkRadius, GrondLayer);
        isGroundCheck = Physics2D.OverlapCircle(groundCheck.position, checkRadius, GrondLayer);
        isGroundDop = Physics2D.OverlapCircle(groundDop.position, checkRadius, GrondLayer);
        PlayerCheck = Physics2D.OverlapCircle(playerCheck.position, CheckPlayer, PlayerCheckLayer);
    }

    private IEnumerator JumpWolf()
    {
        yield return new WaitForSeconds(0.5f);
        JumpForse = 0;

    }
    

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(playerCheck.position, CheckPlayer);
    }

    public void StopHunding()
    {
        rb.velocity = Vector2.zero;
        speed = 0;
        anim.SetBool("RunWolf", false);
    }

   
  
}
