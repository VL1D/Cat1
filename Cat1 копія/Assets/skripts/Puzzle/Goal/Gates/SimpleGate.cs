using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleGate : MonoBehaviour
{
    private bool Pressing;
    private float speed;
    public Transform pointsUp;
    public Transform pointsDown;
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
        if(collision.tag == "Player")
        {
            Pressing = true;
            speed = 10f;
            collision.gameObject.transform.SetParent(gameObject.transform);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            Pressing = false;
            speed = 15f;
            collision.gameObject.transform.SetParent(null);
        }
    }

    public void PressButt()
    {
        if (Pressing)
        {
            if (transform.position.y > pointsDown.position.y)
            {
                transform.Translate(Vector2.down * speed * Time.deltaTime);
            }
        }
        else
        {
            if (transform.position.y < pointsUp.position.y)
            {
                transform.Translate(Vector2.up * speed * Time.deltaTime);
            }
        }
    }
}
