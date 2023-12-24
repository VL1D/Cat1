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

    private void Start()
    {
        anim = GetComponent<Animator>();
        waitTime = StartWaitTime;
        randomspot = Random.Range(0, points.Length);
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        transform.position = Vector2.MoveTowards(transform.position, points[randomspot].position, speed * Time.deltaTime);
        if (Vector2.Distance(transform.position, points[randomspot].position) < 0.2f)
        {

            if (waitTime <= 0)
            {
                randomspot = Random.Range(0, points.Length);
                waitTime = StartWaitTime;
                speed = 30f;
                if (transform.position.x <= points[randomspot].position.x)
                {
                    transform.eulerAngles = new Vector3(0, 180, 0);
                }
                else if (transform.position.x >= points[randomspot].position.x)
                {
                    transform.eulerAngles = new Vector3(0, 0, 0);
                }

            }
            else
            {
                waitTime -= Time.deltaTime;
                speed = 0f;

            }
        }
        if(speed == 0f)
        {
            anim.SetBool("Walking", false);
        }
        else
        {
            anim.SetBool("Walking", true);
        }
    }
}
