using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrivingPlatform : MonoBehaviour
{
    public float speed;
    public Transform[] pointTrans;

    public LeverArm lever;
    public ButtGates Butt;
    public Animator[] gat;

    public bool rises ;

    private void FixedUpdate()
    {
        if(Butt.OpenBut == true & lever.Blocking == false)
        {
            rises = true;
        }
        else if(Butt.OpenBut == true & lever.Blocking == true) 
        {
            rises = false;
        }
        if (!rises)
        {
            if(lever.Blocking == true)
            {
                if (transform.position.y > pointTrans[0].position.y)
                {
                    transform.Translate(Vector2.down * speed * Time.deltaTime);
                    gat[0].SetBool("isOpen", true);
                    gat[0].SetBool("isClose", false);
                    gat[1].SetBool("isOpen", true);
                    gat[1].SetBool("isClose", false);
                    if (transform.position.y <= pointTrans[0].position.y)
                    {
                        gat[0].SetBool("isOpen", false);
                        gat[0].SetBool("isClose", false);
                        gat[1].SetBool("isOpen", false);
                        gat[1].SetBool("isClose", false);
                    }
                }
            }
        }
        else
        {
            if(lever.Blocking == false)
            {
                if (transform.position.y < pointTrans[1].position.y)
                {
                    transform.Translate(Vector2.up * speed * Time.deltaTime);
                    gat[0].SetBool("isOpen", false);
                    gat[0].SetBool("isClose", true);
                    gat[1].SetBool("isOpen", false);
                    gat[1].SetBool("isClose", true);
                    if (transform.position.y >= pointTrans[1].position.y)
                    {
                        gat[0].SetBool("isOpen", false);
                        gat[0].SetBool("isClose", false);
                        gat[1].SetBool("isOpen", false);
                        gat[1].SetBool("isClose", false);
                    }
                }
            }
            else
            {
                rises = false;
            }
        }
    }
}
