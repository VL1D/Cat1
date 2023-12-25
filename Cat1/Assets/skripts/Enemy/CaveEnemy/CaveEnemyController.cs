using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaveEnemyController : MonoBehaviour
{
    public float speed;
    private Animator anim;
    public Transform[] points;

    private float waitTime;
    public float StartWaitTime;
    private int randomspot;

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
        if (speed != 0f)
        {
             anim.SetBool("Walking", true);
        }
        else
        {
             anim.SetBool("Walking", false);
        }

    }
    
}
