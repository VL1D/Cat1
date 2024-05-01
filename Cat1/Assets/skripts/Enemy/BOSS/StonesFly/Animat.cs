using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animat : MonoBehaviour
{

    public float speed;
    private float waitTime;
    public float StartWaitTime;

    public Transform[] moveSports;
    private int randomspot;
    public Animator anim;

    public bool ACT;

    void Start()
    {
        waitTime = StartWaitTime;
        randomspot = Random.Range(0, moveSports.Length);

    }
    private void FixedUpdate()
    {
        transform.position = Vector2.MoveTowards(transform.position, moveSports[randomspot].position, speed * Time.deltaTime);
        if (Vector2.Distance(transform.position, moveSports[randomspot].position) < 0.2f)
        {

            if (waitTime <= 0)
            {
                randomspot = Random.Range(0, moveSports.Length);
                waitTime = StartWaitTime;
                speed = 25f;

            }
            else
            {
                waitTime -= Time.deltaTime;
                speed = 0f;

            }

        }
        if (ACT)
        {
            anim.SetBool("act", true);
        }
        else
        {
            anim.SetBool("act", false);
        }

    }

    public void Stop()
    {
        ACT = false;
        speed = 25f;
    }


}
