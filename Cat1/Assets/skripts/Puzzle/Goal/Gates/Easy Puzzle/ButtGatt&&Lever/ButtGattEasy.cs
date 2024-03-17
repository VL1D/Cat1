using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtGattEasy : MonoBehaviour
{
    private bool Pressing;
    private float speed;
    public Transform pointsUp;
    public TrigLever lever;
    public bool OpGatt;
    private void FixedUpdate()
    {
        PressButt();
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player" || collision.tag == "Box")
        {
            Pressing = true;
            speed = 10f;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Pressing = false;
            speed = 15f;
        }
    }

    public void PressButt()
    {
        if (lever.Blocking)
        {
            OpGatt = false;
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
            OpGatt = true;
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
