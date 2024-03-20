using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtGat : MonoBehaviour
{
    private bool Pressing;
    private float speed;
    public Transform pointsUp;
    public LeverBlocGat lever;
    private void FixedUpdate()
    {
        PressButt();
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player" || collision.tag == "Box")
        {
            Pressing = true;
            speed = 25f;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Pressing = false;
            speed = 25f;
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
