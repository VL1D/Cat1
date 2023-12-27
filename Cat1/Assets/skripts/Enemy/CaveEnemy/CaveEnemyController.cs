using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaveEnemyController : MonoBehaviour
{
    public float speed;
    public Animator anim;
    public Transform[] points;

    private float waitTime;
    public float StartWaitTime;
    private int randomspot;

    public GameObject trigAtack;

     public Transform Cat;
    public Transform CatKill;
    public Rigidbody2D rbCat;

    public bool activeMove ;

    private void Start()
    {
        anim = GetComponent<Animator>();
        waitTime = StartWaitTime;
        randomspot = Random.Range(0, points.Length);
        activeMove = true;
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        if (activeMove )
        {
            transform.position = Vector2.MoveTowards(transform.position, points[randomspot].position, speed * Time.deltaTime);
            if (Vector2.Distance(transform.position, points[randomspot].position) < 0.2f)
            {

                if (waitTime <= 0)
                {
                    randomspot = Random.Range(0, points.Length);
                    waitTime = StartWaitTime;
                    speed = 30f;

                }
                else
                {
                    waitTime -= Time.deltaTime;


                }
            }
            if (transform.position.x <= points[randomspot].position.x)
            {
                transform.eulerAngles = new Vector3(0, 180, 0);
            }
            else if (transform.position.x >= points[randomspot].position.x)
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
            }
        }
        if (speed == 30f)
        {
             anim.SetBool("Walking", true);
        }
        else if(speed > 30f)
        {
            anim.SetBool("Run", true);
            anim.SetBool("Walking", false);
        }
        else if(speed == 0)
        {
            anim.SetBool("Run", false);
        }

    }

    public void DawnAnim()
    {
        activeMove = true;
        speed = 30f;
        anim.SetBool("Walking", true);
    }

    public void TrigActive() 
    {
        trigAtack.SetActive(true);
    }
    public void TrigNoActive()
    {
        trigAtack.SetActive(false);
    }
    public void KillAtack()
    {
        Cat.transform.position = CatKill.position;
        rbCat.isKinematic = true;
    }

}
