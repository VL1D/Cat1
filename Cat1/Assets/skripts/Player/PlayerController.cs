using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

public class PlayerController : AudioManager , IDatPersistence 
{
    public float speed;
    public float normalSpeed;
    public float jumpForce;
    public float checkRadius;
    public float speedUp;
    public float CheckDistans;
    public float DopRadius;
    public float DopSpeed;

    public int CheckPointIND;

    public Animator anim;
    public Rigidbody2D rb;

    private bool isGrounded, isStopRot, isGroundedChek , isDopGround, isBox;
    public bool blockMoveX;
    public bool Climb ;
    public bool isWater = false;
    private bool Deatch = false;
    public bool hidden = false;
    public bool danger = false;

    public Transform feetPos, stopRot, GraundChek, DopGroud;
    public Transform DopPosition;

    private Vector3 _newPosition; 

    public LayerMask whatIsGround;
    public LayerMask whatIsBox;

    public GameObject deathScreen;
    public GameObject peredw;
    public GameObject ButtonPaus;

    [Header("Save")]
    public GameObject Wolf;
    public GameObject FallingStone;
    public GameObject WaterEnemy;
    public GameObject Earth;

    private void Start()
    {
        speed = 0f;
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        
    }
    
    private void FixedUpdate()
    {
        Move();
        Jumping();
        CheckColision();
        StopMove();
        MoveUp();
        posNext();
        WaterRun();
    }

    private void Move()
    {
        if (!Deatch)
        {
            if (!blockMoveX)
            {
                rb.velocity = new Vector2(speed, rb.velocity.y);
                if (speed != 0f)
                {
                    anim.SetBool("Run", true);
                    if (!isGrounded)
                    {
                        anim.SetBool("dawn", true);
                    }
                    else
                    {
                        anim.SetBool("dawn", false);
                    }
                    if (isBox)
                    {
                        anim.SetBool("dawn", false);
                    }
                }
                else
                {
                    anim.SetBool("Run", false);
                    if (!isGrounded)
                    {
                        anim.SetBool("dawn", true);
                    }
                    else
                    {
                        anim.SetBool("dawn", false);
                    }
                    if (isBox)
                    {
                        anim.SetBool("dawn", false);
                    }
                }
            }
        }
        if (Deatch)
        {
            speed = 0f;
            normalSpeed = 0f;
        }
    }
    private void Jumping()
    {
        if (!Deatch)
        {
            if (isGrounded)
            {
                anim.SetBool("Jump", false);
                anim.SetBool("Dawn3", false);
                isWater = false;
            }
            else
            {
                if (isBox)
                {
                    anim.SetBool("Jump", false);
                    anim.SetBool("Dawn3", false);
                }
                else
                {
                    anim.SetBool("Jump", true);
                    //стрибок дугою
                    if (transform.eulerAngles.y == 0)
                    {
                        transform.Rotate(0, 0, -40 * Time.deltaTime);
                        if (isStopRot || isWater == true)
                        {
                            transform.eulerAngles = new Vector3(0, 0, 0);
                        }
                    }
                    //стрибк дугою
                    else if (transform.eulerAngles.y == 180)
                    {
                        transform.Rotate(0, 0, -40 * Time.deltaTime);
                        if (isStopRot || isWater == true)
                        {
                            transform.eulerAngles = new Vector3(0, 180, 0);
                        }
                    }
                    //стрибк на місці
                    if (speed == 0)
                    {
                        if (!isWater)
                        {
                            transform.position += transform.right * 0.4f;
                        }
                    }
                    //врізався в перешкоду
                    if (isGroundedChek && isDopGround)
                    {
                        anim.SetBool("Dawn3", true);
                    }
                }
            }
        }
    }
    public void OnJumpButtonDown()
    {
        if(!isGroundedChek)
        {
            if (isGrounded || isBox)
            {
                 anim.SetTrigger("Trig");
                 rb.velocity = Vector2.up * jumpForce;
                 transform.Rotate(0, 0, 20);
            }
        }
        else
        {
            if (isGrounded || isWater)
            {
                anim.SetTrigger("RunUp");
                rb.velocity = Vector2.up * speedUp;
                isWater = false;
            }
        }
    }
    public void OnLeftButtonDown()
    {
        if (speed >= 0f)
        {

            if (!isGrounded)
            {
                if (isBox)
                {
                    speed = -normalSpeed;
                    transform.eulerAngles = new Vector3(0, 180, 0);
                }
                else
                {
                    if (transform.eulerAngles.y == 0)
                    {
                        transform.eulerAngles = new Vector3(0, 0, 0);
                    }
                }
            }
            else
            {
                speed = -normalSpeed;
                transform.eulerAngles = new Vector3(0, 180, 0);
            }
            if (isWater)
            {
                speed = -normalSpeed;
                transform.eulerAngles = new Vector3(0, 180, 0);
            }
        }
    }
    public void OnRightButtonDown()
    {
        if (speed <= 0f)
        {

            if (!isGrounded)
            {
                
                if (isBox)
                {
                    speed = normalSpeed;
                    transform.eulerAngles = new Vector3(0, 0, 0);
                }
                else
                {
                    if (transform.eulerAngles.y == 180)
                    {
                        transform.eulerAngles = new Vector3(0, 180, 0);
                    }
                }
            }
            else
            {
                speed = normalSpeed;
                transform.eulerAngles = new Vector3(0, 0, 0);
            }
            if (isWater)
            {
                speed = normalSpeed;
                transform.eulerAngles = new Vector3(0, 0, 0);
            }
        }
    }
    public void OnButtonUp()
    {
        speed = 0f;
    }

    private void StopMove()
    {
        if (!Deatch)
        {
            if (isGroundedChek)
            {
                if (speed != 0f)
                {
                    speed = 0;
                    anim.SetBool("Run", false);
                    anim.SetBool("Siting", true);
                }
            }
            else
            {
                if (speed != 0f)
                {
                    anim.SetBool("Run", true);
                    anim.SetBool("Siting", false);
                }
                else
                {
                    anim.SetBool("Run", false);
                    anim.SetBool("Siting", false);
                }
            }
        }
    }

    private void MoveUp()
    {
        if (!Deatch)
        {
            if (!isGrounded)
            {
                if (isGroundedChek && isDopGround)
                {
                    anim.SetBool("Dawn3", true);
                }
            }
            else
            {
                if (isGroundedChek && isDopGround)
                {
                    anim.SetBool("Dawn3", false);
                }
            }
        }
    }

    private void CheckColision()
    {
        isGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, whatIsGround);
        isStopRot = Physics2D.OverlapCircle(stopRot.position, checkRadius, whatIsGround);
        isGroundedChek = Physics2D.OverlapCircle(GraundChek.position, checkRadius, whatIsGround);
        isDopGround = Physics2D.OverlapCircle(DopGroud.position, CheckDistans, whatIsGround);
        isBox = Physics2D.OverlapCircle(feetPos.position, CheckDistans, whatIsBox);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(DopPosition.position, DopRadius);
    }

    public void LendeGo()
    {
        transform.position = new Vector3(DopPosition.position.x  , DopPosition.position.y, transform.position.z);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.tag == "Respawn")
        {
            if (!deathScreen.activeSelf)
            {
                deathScreen.SetActive(true);
                anim.SetTrigger("Deatch");
                speed = 0;
                normalSpeed = 0;
                jumpForce = 0;
                ButtonPaus.SetActive(false);
                peredw.SetActive(false);
                Deatch = true;
            }
        }
        if(other.tag == "Water")
        {
            isWater = true;
            speed = 0;
        }
    }

    public void StartAnimLedge()
    {
        rb.velocity = Vector2.zero;
        anim.Play("up1");
    }

    public void posNext() 
    {
        if (Climb)
        {
            if(transform.eulerAngles.y == 0)
            {
                _newPosition = new Vector3(transform.position.x + DopSpeed , transform.position.y, transform.position.z);
                transform.position = _newPosition;
            }
            else if (transform.eulerAngles.y == 180)
            {
                _newPosition = new Vector3(transform.position.x + -DopSpeed, transform.position.y, transform.position.z);
                transform.position = _newPosition;
            }

        }
    }
 
    public void LoadData(GameData data)
    {
        this.transform.position = data.playerPosition;
        if (DataCheck.checkPointIndex == 5)
        {
            Wolf.SetActive(true);
            Wolf.transform.position = new Vector3(2555, 52, transform.position.z);
        }
        if (DataCheck.checkPointIndex >= 4)
        {
            Destroy(FallingStone);
        }
        if (DataCheck.checkPointIndex >= 13)
        {
            Destroy(WaterEnemy);
            Destroy(Wolf);
            Earth.transform.position = new Vector3(6886, -25, transform.position.z);
        }
    }

    public void SaveData( GameData data)
    {
        data.playerPosition = this.transform.position;
        if (DataCheck.checkPointIndex == 5)
        {
            Wolf.SetActive(true);
            Wolf.transform.position = new Vector3(2555, 52, transform.position.z);
        }
        if (DataCheck.checkPointIndex >= 4)
        {
            Destroy(FallingStone);
        }
        if (DataCheck.checkPointIndex >= 13)
        {
            Destroy(WaterEnemy);
            Destroy(Wolf);
            Earth.transform.position = new Vector3(6886,-26,transform.position.z);
        }
    }

    private void WaterRun()
    {
        if (isWater)
        {
            normalSpeed = 20;
            anim.SetBool("go", true);
           
        }
        else
        {
            normalSpeed = 40;
            anim.SetBool("go", false);
           
        }
    }

}
