using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtGates : MonoBehaviour
{
    public Gates[] gates;
    public bool OpenBut = false;
    public float speed;
    public Transform[] ButPoints;
    public LeverArm arm;

    public bool Stop;
    private void FixedUpdate()
    {
        if (OpenBut)
        {
            if(transform.position.y > ButPoints[0].transform.position.y)
            {
                transform.Translate(Vector2.down * speed * Time.deltaTime);
            }
        }
        else
        {
            if ((arm.Blocking == true))
            {
                if (transform.position.y < ButPoints[1].transform.position.y)
               {
                    transform.Translate(Vector2.up * speed * Time.deltaTime);
                    gates[0].speed = 16f;
                    gates[1].speed = 16f;
                    gates[0].Open = false;
                    gates[1].Open = false;
                }
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.tag == "Player" || collision.tag == "Box")
        {
            gates[0].speed = 8f;
            gates[1].speed = 8f;
            gates[0].Open = true;
            gates[1].Open = true;
            speed = 10f;
            OpenBut = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player" && arm.Blocking == true || collision.tag == "Box" )
        {
            gates[0].speed = 16f;
            gates[1].speed = 16f;
            gates[0].Open = false;
            gates[1].Open = false;
            speed = 20;
            OpenBut = false;
        }
        if (collision.tag == "Player" && arm.Blocking == false)
        {
            gates[0].Open = true;
            gates[1].Open = true;
            OpenBut = false;
            speed = 20;
        }
    }
}
