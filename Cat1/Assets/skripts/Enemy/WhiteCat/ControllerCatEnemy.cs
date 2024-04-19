using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerCatEnemy : MonoBehaviour
{
    public float speed;
    public float DistansRL;
    public Transform CatPoints;
    //private Rigidbody2D rb;
    public bool Atack;

    private void Start()
    {
        //rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (Atack)
        {
            AtackCat();
        }
        else 
        {
            StopAtack();
        }
    }

    private void AtackCat()
    {
        speed = 17f;
        transform.position = Vector2.Lerp(transform.position, CatPoints.position, Time.deltaTime * speed);
    }

    private void StopAtack()
    {
        speed = 0f;
    }

    private void OnTriggerEnter2D (Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            Atack = false;
            if(transform.eulerAngles.y == 0)
            {
                transform.eulerAngles = new Vector3(0, 180, 0);
                transform.position = new Vector2(transform.position.x + DistansRL, transform.position.y);
            }
            else if (transform.eulerAngles.y == 180)
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                transform.position = new Vector2(transform.position.x - DistansRL, transform.position.y);
            }
        }
    }

}