using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtGattEasy : MonoBehaviour
{
    private bool Pressing;
    private float speed;
    public Transform pointsUp;
    public TrigLever lever;
    private void FixedUpdate()
    {
        PressButt();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.gameObject.transform.SetParent(gameObject.transform);
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player" )
        {
            Pressing = true;
            speed = 25f;
        }
        if (collision.tag == "Box")
        {
            Pressing = true;
            speed = 0f;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Pressing = false;
            speed = 25f;
            collision.gameObject.transform.SetParent(null);
        }
    }

    public void PressButt()
    {
        if (lever.Blocking)
        {
            if (Pressing)
            {
                transform.Translate(Vector2.down * speed * Time.deltaTime);
            }
            else
            {
                if (transform.position.y < pointsUp.position.y)
                {
                    transform.Translate(Vector2.up * speed * Time.deltaTime);
                }
            }
        }
        else
        {
            if (Pressing)
            {
                transform.Translate(Vector2.down * speed * Time.deltaTime);
            }
            else
            {
                return;
            }
        }
    }
}
