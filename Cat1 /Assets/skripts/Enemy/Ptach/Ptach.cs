using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ptach : MonoBehaviour
{
    public float speed;
    public float flightSpeed;
    private float waitTime;
    public float StartWaitTime;

    public Transform[] moveSports;
    private int randomspot;

    private Animator _Ptach;
    void Start()
    {
        waitTime = StartWaitTime;
        randomspot = Random.Range(0, moveSports.Length);
        _Ptach = GetComponent<Animator>();

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
                speed = 2f;
                if (transform.position.x <= moveSports[randomspot].position.x)
                {
                    transform.eulerAngles = new Vector3(0, 0, 0);
                }
                else if (transform.position.x >= moveSports[randomspot].position.x)
                {
                    transform.eulerAngles = new Vector3(0, 180, 0);
                }

            }
            else
            {
                waitTime -= Time.deltaTime;
                speed = 0f;
                
            }
           
        }
        if(flightSpeed != 0)
        {
            transform.position += transform.up * flightSpeed;
            transform.position += transform.right * flightSpeed;
        }
        if (speed != 0f)
        {
            _Ptach.SetBool("isWalk", true);
        }
        else
        {
            _Ptach.SetBool("isWalk", false);
        }
      

    }

   
}
