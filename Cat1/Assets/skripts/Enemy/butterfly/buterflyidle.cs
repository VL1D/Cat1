using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

public class buterflyidle : MonoBehaviour
{
    public GameObject[] points;
    public float speed;
    public Animator anim;

    public bool fielsCircle;
    public bool fiels;
    public bool BoxFly;
    
    private bool Ground;
    public bool GrounCheck;
    public LayerMask ground;
    public Transform posit;
    public Transform Groundch;
    public float checkRadius;
    public Transform BoxPoint;
    public bool Fly_run;


    private void FixedUpdate()
    {
        CeckContr();
        if (!BoxFly)
        {
            if (fiels)
            {
                FielesFly();
            }
            else
            {
                LadtFlay();
            }
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, BoxPoint.transform.position, 40f * Time.deltaTime);
            if(transform.position == BoxPoint.position)
            {
                anim.SetBool("fieles", true);
            }
        }
        if (Fly_run)
        {
            transform.Translate(Vector2.right * 40f * Time.deltaTime);
            transform.Translate(Vector2.up * 15f * Time.deltaTime);
            anim.SetBool("fieles", false);
        }
    }

    public void FielesFly()
    {
        anim.SetBool("fieles", false);
        if (!fielsCircle)
        {
            transform.position = Vector2.MoveTowards(transform.position, points[0].transform.position, speed * Time.deltaTime);
            if (transform.position == points[0].transform.position)
            {
                fielsCircle = true;
            }
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, points[1].transform.position, speed * Time.deltaTime);
            if (transform.position == points[1].transform.position)
            {
                fielsCircle = false;
            }
        }

    }

    public void LadtFlay()
    {
        if (!Ground)
        {
            transform.Translate(Vector2.down * speed * Time.deltaTime);
        }
        else
        {
            anim.SetBool("fieles", true);
        }
    }

   

    private void CeckContr()
    {
        Ground = Physics2D.OverlapCircle(posit.transform.position, checkRadius, ground);
        GrounCheck = Physics2D.OverlapCircle(Groundch.transform.position, checkRadius, ground);
    }
}
