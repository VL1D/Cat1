using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtGates : MonoBehaviour
{
    public Gates[] gates;
    private bool OpenBut = false;
    public float speed;
    public Transform[] ButPoints;
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
            if (transform.position.y < ButPoints[1].transform.position.y)
            {
                transform.Translate(Vector2.up * speed * Time.deltaTime);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            gates[0].speed = 8f;
            gates[1].speed = 8f;
            gates[0].Open = true;
            gates[1].Open = true;
            speed = 4f;
            OpenBut = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            gates[0].speed = 4f;
            gates[1].speed = 4f;
            gates[0].Open = false;
            gates[1].Open = false;
            speed = 20;
            OpenBut = false;
        }
    }
}
