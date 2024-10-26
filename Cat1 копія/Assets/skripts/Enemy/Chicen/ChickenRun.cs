using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenRun : MonoBehaviour
{
    public float speed;
    private float waitTime;
    public float StartWaitTime;

    public Transform[] moveSports;
    private int randomspot;

    private Animator anim;
    void Start()
    {
        waitTime = StartWaitTime;
        randomspot = Random.Range(0, moveSports.Length);
        anim = GetComponent<Animator>();

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
                speed = 10f;
                if (transform.position.x <= moveSports[randomspot].position.x)
                {
                    transform.eulerAngles = new Vector3(0, 180, 0);
                }
                else if (transform.position.x >= moveSports[randomspot].position.x)
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
        if (speed != 0)
        {
            anim.SetBool("run", true);
            anim.SetBool("peck", false);
        }
        else
        {
            anim.SetBool("run", false);
            anim.SetBool("peck", true);
        }
    }
}
