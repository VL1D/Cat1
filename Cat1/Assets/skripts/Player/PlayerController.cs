using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Scripting.APIUpdating;
using UnityEngine.UI;

public class PlayerController : AudioManager , IDatPersistence, IPointerDownHandler , IPointerUpHandler
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

    private bool isGrounded, isStopRot, isGroundedChek , isDopGround, isBox , isStopRotBox, isBoxChech;
    public bool blockMoveX;
    public bool Climb ;
    public bool isWater = false;
    public bool Deatch = false;
    public bool hidden = false;
    public bool danger = false;
    public bool BlokRotY = false;
    public bool Run;
    public bool MovingUp;
    public bool jump;
    public bool RunUP;
    private bool RunRight;
    private bool RunLeft;
    public bool rev;
    public bool WolfAt;
    public bool Dawn;
    private bool StopCat;
    public bool jumpbutt;
    public bool touch;


    public Transform feetPos, stopRot, GraundChek, DopGroud;
    public Transform DopPosition;

    private Vector3 _newPosition; 

    public LayerMask whatIsGround;
    public LayerMask whatIsBox;
    public LayerMask whatIsStopCat;

    public GameObject deathScreen;
    public GameObject peredw;
    public GameObject ButtonPaus;
    public GameObject BoxKill;

    [Header("SaveEnemy")]
    public GameObject Wolf;
    public GameObject[] Enemy;

    [Header("SaveEnvir")]
    public GameObject[] Falling;

    [Header("SavePuzzle")]
    public GameObject[] Puzzle;

    [Header("SaveBackground")]
    public GameObject[] Background;

    [Header("Audio")]
    public GameObject[] AudioCat;

    [Header("NameLevel")]
    public GameObject[] SaveName;



    private void Start()
    {
        speed = 0f;
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        BoxKill.SetActive(false);
        
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
        MoveBox();
        if(Deatch && isWater)
        {
            rb.mass = 50f;
        }
        if (!Deatch)
        {
            BoxKill.transform.position = transform.position;
        }

        if (touch)
        {
            rev = false;
        }
        if (!rev)
        {
            anim.SetBool("rev", false);
        }
        else
        {
            anim.SetBool("rev", true);
        }
    }

    private void Move()
    {
        if (!blockMoveX )
        {
            if (!Deatch)
            {
                rb.velocity = new Vector2(speed, rb.velocity.y);
                if (speed != 0f && !WolfAt)
                {
                    anim.SetBool("tash", false);
                    anim.SetBool("Run", true);
                    if (!Climb)
                    {
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
                else
                {
                    anim.SetBool("Run", false);
                    if (!Climb)
                    {
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

                if (Run && !MovingUp && !Climb && !jump && !rev && isGrounded || Run && !MovingUp && !Climb && !jump && !rev && isBox )
                {
                    if (RunRight)
                    {
                        RunLeft = false;
                        speed = 40f;
                       // transform.eulerAngles = new Vector2(0, 0);
                       if(transform.eulerAngles.y == 180)
                       {
                            anim.SetBool("rev", true);
                       }
                    }
                    else if (RunLeft)
                    {
                        RunRight = false;
                        speed = -40f;
                        //transform.eulerAngles = new Vector2(0, 180);
                        if (transform.eulerAngles.y == 0)
                        {
                            anim.SetBool("rev", true);
                       }
                    }
                }
                if (!Run)
                {
                    speed = 0;
                }
            }
            if (Deatch)
            {
                speed = 0f;
                normalSpeed = 0f;
            }
        }
    }
    private void Jumping()
    {

        if (!Deatch)
        {
            if (isGrounded)
            {
                rb.gravityScale = 5f;
                anim.SetBool("Jump", false);
                anim.SetBool("Dawn3", false);
                isWater = false;
                jump = false;
                rev = false;
                if (jumpbutt && !RunUP && !rev)
                {
                    transform.Rotate(0, 0, 20);
                    if (RunRight)
                    {
                        transform.eulerAngles = new Vector2(0, 0);
                    }
                    else if(RunLeft)
                    {
                        transform.eulerAngles = new Vector2(0, 180);
                    }
                }
            }
            else
            {
                
                if (isBox)
                {
                    rb.gravityScale = 5f;
                    anim.SetBool("Jump", false);
                    anim.SetBool("Dawn3", false);
                    jump = false;
                    if (jumpbutt)
                    {
                        if (RunRight)
                        {
                            transform.eulerAngles = new Vector2(0, 0);
                        }
                        else if (RunLeft)
                        {
                            transform.eulerAngles = new Vector2(0, 180);
                        }
                    }
                }
                else
                {
                    rev = false;
                    if (!RunUP && !RunUP && !rev)
                    {
                        if (RunRight)
                        {
                            JumpRunR();
                        }

                        else if (RunLeft)
                        {
                            JumpRunL();
                        }
                    }
                    anim.SetBool("Jump", true);
                    //??????? ?????
                    if (transform.eulerAngles.y == 0 && !Dawn)
                    {
                        transform.Rotate(0, 0, -40 * Time.deltaTime);
                        if (isStopRot || isWater == true || isStopRotBox)
                        {
                            transform.eulerAngles = new Vector3(0, 0, 0);
                        }
                    }
                    //?????? ?????
                    else if (transform.eulerAngles.y == 180 && !Dawn)
                    {
                        transform.Rotate(0, 0, -40 * Time.deltaTime);
                        if (isStopRot || isWater == true || isStopRotBox)
                        {
                            transform.eulerAngles = new Vector3(0, 180, 0);
                        }
                    }
                    //?????? ?? ?????
                    if (speed == 0)
                    {
                        if (!isWater)
                        {
                            transform.position += transform.right * 0.4f;

                        }
                    }
                    //???????? ? ?????????
                    if (isGroundedChek && isDopGround)
                    {
                        anim.SetBool("Dawn3", true);
                    }
                }
            }
            if (!isGrounded && !isBox)
            {
                jump = true;
            }
        }
    }

    private void JumpRunL()
    {
        RunRight = false;
        transform.Rotate(0, 0, -5 * Time.deltaTime);
        if (isStopRot || isWater == true || isStopRotBox)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
    }

    private void JumpRunR()
    {
        RunLeft = false;
        transform.Rotate(0, 0, -5 * Time.deltaTime);
        if (isStopRot || isWater == true || isStopRotBox)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
    }

    private void MoveBox()
    {
        if (isBoxChech )
        {
            if (Run)
            {
                anim.SetBool("Run", false);
                anim.SetBool("tash", true);
                if (RunRight)
                {
                    speed = 20f;
                }
                else if (RunLeft)
                {
                    speed = -20f;
                }
            }
            else
            {
                anim.SetBool("tash", false);
                anim.SetBool("Siting", true);
            }
        }
        else
        {
            anim.SetBool("tash", false);
        }
    }

    public void OnJumpButtonDown()
    {
        
        if (!Deatch)
        {
            if (!StopCat)
            {
                
                if (!isGroundedChek)
                {
                    if (isGrounded || isBox)
                    {
                        jumpbutt = true;
                        jump = true;
                        anim.SetTrigger("Trig");
                        rb.velocity = Vector2.up * jumpForce;
                        transform.Rotate(0, 0, 20);
                        Dawn = false;
                    }
                }
                else
                {
                    if (isGrounded || isWater || isBox)
                    {
                        anim.SetTrigger("RunUp");
                        rb.velocity = Vector2.up * speedUp;
                        isWater = false;
                    }
                }
            }
        }
    }

    public void OnJumpButtonUp()
    {
        jumpbutt = false;
    }


    public void OnLeftButtonDown()
    {
        if (RunRight)
        {
            return;
            speed = -normalSpeed;
            transform.eulerAngles = new Vector3(0, 180, 0);
            Dawn = false;
        }
        if (!Deatch && !RunRight || !blockMoveX && !RunRight)
        {
            Run = true;
            RunLeft = true;
            if (transform.eulerAngles.y == 180 )
            {
                if (speed >= 0f)
                {

                    if (!isGrounded)
                    {
                        if (isBox)
                        {
                            if(!jump)
                            {
                                speed = -normalSpeed;
                                transform.eulerAngles = new Vector3(0, 180, 0);
                            }
                        }
                    }
                    else
                    {
                        if (!jump)
                        {
                            speed = -normalSpeed;
                            transform.eulerAngles = new Vector3(0, 180, 0);
                            Dawn = false;
                        }
                    }
                    if (isWater)
                    {
                        if (!jump)
                        {
                            speed = -normalSpeed;
                            transform.eulerAngles = new Vector3(0, 180, 0);
                            Dawn = false;
                        }
                    }
                }
            }
            else if (transform.eulerAngles.y == 0)
            {
                if (isGrounded || isWater || isBox )
                {
                    anim.SetBool("tash", false);
                    anim.SetBool("rev", true);
                    rev = true;
                    if (isGroundedChek || StopCat || isBoxChech)
                    {
                        anim.SetBool("tash", false);
                        anim.SetBool("Siting", false);
                    }
                }
                else if (isBoxChech)
                {
                    anim.SetBool("tash", false);
                    //anim.SetTrigger("mem");
                    anim.SetBool("rev", true);
                }

            }
        }
    }
    public void OnRightButtonDown()
    {
        if (RunLeft)
        {
            return;
            speed = normalSpeed;
            transform.eulerAngles = new Vector3(0, 0, 0);
            Dawn = false;
        }
        if (!Deatch && !RunLeft || !blockMoveX && !RunLeft)
        {
            Run = true;
            RunRight = true;
            if (transform.eulerAngles.y == 0 )
            {
                if (speed <= 0f)
                {

                    if (!isGrounded)
                    {

                        if (isBox)
                        {
                            if (!jump)
                            {
                                speed = normalSpeed;
                                transform.eulerAngles = new Vector3(0, 0, 0);
                            }
                        }
                    }
                    else
                    {
                       if(!jump)
                        {
                            speed = normalSpeed;
                            transform.eulerAngles = new Vector3(0, 0, 0);
                            Dawn = false;
                        }

                    }
                    if (isWater)
                    {
                        if (!jump)
                        {
                            speed = normalSpeed;
                            transform.eulerAngles = new Vector3(0, 0, 0);
                            Dawn = false;
                        }
                    }
                }
            }
            else if (transform.eulerAngles.y == 180  )
            {
                if (isGrounded || isWater || isBox)
                {
                    anim.SetBool("tash", false);
                    anim.SetBool("rev", true);
                    rev = true;
                    if (isGroundedChek || StopCat || isBoxChech)
                    {
                        anim.SetBool("tash", false);
                        anim.SetBool("Siting", false);
                    }
                }
                else if (isBoxChech)
                {
                    anim.SetBool("tash", false);
                    anim.SetBool("rev", true);
                }
            }
        }
    }
    public void OnButtonUp()
    {
        speed = 0f;
        Run = false;
        RunRight = false;
        RunLeft = false;
        //anim.SetBool("rev", false);
    }

    private void StopMove()
    {
        if (!Deatch)
        {
            if (isGroundedChek || StopCat )
            {
                if (speed != 0f || speed == 0)
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
            if (!isGrounded && !isBox || !isGrounded)
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
        isStopRotBox = Physics2D.OverlapCircle(stopRot.position, checkRadius, whatIsBox);
        isBoxChech = Physics2D.OverlapCircle(GraundChek.position, checkRadius, whatIsBox);
        StopCat = Physics2D.OverlapCircle(GraundChek.position, checkRadius, whatIsStopCat);
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

        if (other.tag == "Respawn" || other.tag == "RespawnMonster")
        {
            if (!deathScreen.activeSelf)
            {
                deathScreen.SetActive(true);
                speed = 0;
                normalSpeed = 0;
                jumpForce = 0;
                ButtonPaus.SetActive(false);
                peredw.SetActive(false);
                Deatch = true;
                hidden = false;
                Run = false;
                gameObject.layer = 20;
            }
        }
        if(other.tag == "Respawn")
        {
            anim.SetTrigger("Deatch");
            BoxKill.SetActive(true);
        }
        else if(other.tag == "RespawnMonster")
        {
            anim.SetTrigger("DeatchMonster");
        }
        if(other.tag == "Water")
        {
            isWater = true;
            speed = 0;
            AudioCat[2].SetActive(true);
        }
    }

    public void StartAnimLedge()
    {
        if (!Deatch)
        {
            rb.velocity = Vector2.zero;
            anim.Play("up1");
        }
    }

    public void posNext() 
    {
        if (Climb)
        {
            if (transform.eulerAngles.y == 0)
            {
                _newPosition = new Vector3(transform.position.x + DopSpeed, transform.position.y, transform.position.z);
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
        if(DataCheck.checkPointIndex >= 1)
        {
            Background[0].SetActive(false);
            Background[1].SetActive(true);
            Destroy(Enemy[2]);
        }
        if (DataCheck.checkPointIndex >= 2)
        {
            Destroy(SaveName[0]);
        }
        if (DataCheck.checkPointIndex == 5)
        {
            Wolf.SetActive(true);
            Enemy[5].SetActive(true);
            Wolf.transform.position = new Vector3(2555, 52, transform.position.z);
        }
        if (DataCheck.checkPointIndex >= 7)
        {
            Destroy(SaveName[1]);
        }
        if (DataCheck.checkPointIndex >= 7 && DataCheck.checkPointIndex <= 12)
        {
            Wolf.SetActive(false);
            Enemy[0].SetActive(true);
        }
        if (DataCheck.checkPointIndex >= 12)
        {
            if (DataCheck.checkPointIndex <= 19)
            {
                Enemy[1].SetActive(true);
                Falling[1].SetActive(true);
            }
            if (DataCheck.checkPointIndex >= 19)
            {
                Destroy(Falling[1]);
                Destroy(Enemy[1]);
            }
        }
        if (DataCheck.checkPointIndex >= 4)
        {
            Destroy(Falling[0]);
        }
        if (DataCheck.checkPointIndex >= 13)
        {
            Destroy(Enemy[0]);
            Destroy(Enemy[5]);
            Destroy(Wolf);
            if (DataCheck.checkPointIndex <= 19)
            {
                Falling[1].transform.position = new Vector3(6886, -23, transform.position.z);
            }
            else
            {
                Destroy(Falling[1]);
            }
        }
        if (DataCheck.checkPointIndex >= 14)
        {
            Destroy(SaveName[2]);
        }
        if (DataCheck.checkPointIndex >= 18 )
        {
            Puzzle[0].SetActive(true);
            
        }
        if (DataCheck.checkPointIndex >= 20)
        {
            Destroy(SaveName[3]);
        }
        if (DataCheck.checkPointIndex >= 24)
        {
            Enemy[3].SetActive(true);
            Destroy(SaveName[4]);
        }

        if (DataCheck.checkPointIndex == 28)
        {
            Enemy[4].SetActive(true);
        }

    }

    public void SaveData( GameData data)
    {
        data.playerPosition = this.transform.position;
        if (DataCheck.checkPointIndex >= 1)
        {
            Background[0].SetActive(false);
            Background[1].SetActive(true);
            Destroy(Enemy[2]);
        }
        if (DataCheck.checkPointIndex >= 2)
        {
            Destroy(SaveName[0]);
        }
        if (DataCheck.checkPointIndex == 5)
        {
            Wolf.SetActive(true);
            Wolf.transform.position = new Vector3(2555, 52, transform.position.z);
            Enemy[5].SetActive(true);
        }
        if (DataCheck.checkPointIndex >= 7)
        {
            Destroy(SaveName[1]);
        }
        if (DataCheck.checkPointIndex >= 7 && DataCheck.checkPointIndex <= 12)
        {
            Wolf.SetActive(false);
            Enemy[0].SetActive(true);
        }
        if (DataCheck.checkPointIndex >= 12 )
        {
            if (DataCheck.checkPointIndex <= 19)
            {
                Enemy[1].SetActive(true);
                Falling[1].SetActive(true);
            }
            if (DataCheck.checkPointIndex >= 19)
            {
                Destroy(Falling[1]);
                Destroy(Enemy[1]);
            }
        }
        if (DataCheck.checkPointIndex >= 4)
        {
            Destroy(Falling[0]);
        }
        if (DataCheck.checkPointIndex >= 13)
        {
            Destroy(Enemy[0]);
            Destroy(Enemy[5]);
            Destroy(Wolf);
            if (DataCheck.checkPointIndex <= 19)
            {
                Falling[1].transform.position = new Vector3(6886, -23, transform.position.z);
            }
            else
            {
                Destroy(Falling[1]);
            }

        }
        if (DataCheck.checkPointIndex >= 14)
        {
            Destroy(SaveName[2]);
        }
        if (DataCheck.checkPointIndex >= 18)
        {
            Puzzle[0].SetActive(true);
        }

        if (DataCheck.checkPointIndex >= 20)
        {
            Destroy(SaveName[3]);
        }
        if (DataCheck.checkPointIndex >= 24)
        {
            Enemy[3].SetActive(true);
            Destroy(SaveName[4]);
        }

        if (DataCheck.checkPointIndex == 28)
        {
            Enemy[4].SetActive(true);
        }
    }

    private void WaterRun()
    {
        if (isWater)
        {
            normalSpeed = 20;
            anim.SetBool("go", true);
            if (Run && !rev)
            {
                if (RunRight)
                {
                    speed = 20f;
                    transform.eulerAngles = new Vector3(0, 0, 0);


                }
                else if (RunLeft)
                {
                    speed = -20f;
                    transform.eulerAngles = new Vector3(0, 180, 0);

                }
            }
            if (!Run)
            {
                speed = 0;
            }

        }
        else
        {
            AudioCat[2].SetActive(false);
            normalSpeed = 40;
            anim.SetBool("go", false);
           
        }
    }

    public void MemRigcht()
    {
        if (!jump)
        {
            rev = false;
            if (transform.eulerAngles.y == 180)
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
            }
            else if (transform.eulerAngles.y == 0)
            {
                transform.eulerAngles = new Vector3(0, 180, 0);
            }
        }
    }

    public void noAtackWolf()
    {
        anim.SetBool("wolfAtack", false);
    }
    public void AtackWolf()
    {
        anim.SetBool("wolfAtack", true);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
         anim.SetBool("roll", false);
         AudioCat[0].SetActive(false);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        
         if(!Run && !jump && !Climb && !MovingUp && !rev && !isBoxChech && !isWater && !isGroundedChek && !Deatch )
         {
             anim.SetBool("roll", true);
             AudioCat[0].SetActive(true);
         }
    } 

    public void DawnAnim()
    {
        rb.gravityScale = 10f;
    }


    public void DeatchEnd()
    {
        anim.SetTrigger("Deatch");
    }

    public void AudioFall()
    {
        AudioCat[1].SetActive(true);
    }
    public void AudioFallNo()
    {
        AudioCat[1].SetActive(false);
    }

    public void PosJump()
    {
        rev = false;
        if (RunLeft)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
            if (jumpbutt || jump)
            {
                transform.Rotate(0, 0, 20);
            }
        }
        else if (RunRight)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
            if (jumpbutt || jump)
            {
                transform.Rotate(0, 0, 20);
            }
        }
    }

    public void PosTouch()
    {
        rev = false;
        if (RunLeft)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
        else if (RunRight)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
    }

    public void PosRun()
    {
        if (RunLeft)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
        else if (RunRight)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
    }

    public void PosTouc()
    {
        rev = false;
        if (transform.eulerAngles.y == 180)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
        else if (transform.eulerAngles.y == 0)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
    }

    public void AnEnd()
    {
        anim.Play("rev");
    }
}
