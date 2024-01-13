using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gates : MonoBehaviour
{
    public float speed;
    public GameObject Gat;
    public Animator animGat;
    public Transform poinsClose;

    public bool Open = false;
    
    private void FixedUpdate()
    {
        if (Open)
        {
            OpenGat();
        }
        else
        {
            CloseGat();
        }
    }

    private void OpenGat()
    {
        transform.position = Vector2.MoveTowards(transform.position, poinsClose.transform.position, speed * Time.deltaTime);
        animGat.SetBool("isOpen", true);
        if (transform.position == poinsClose.transform.position)
        {
            speed = 0;
            animGat.SetBool("isOpen", false);
        }
    }

    private void CloseGat()
    {
        transform.position = Vector2.MoveTowards(transform.position, Gat.transform.position, speed * Time.deltaTime );
        animGat.SetBool("isClose", true);
        if(transform.position == Gat.transform.position)
        {
            speed = 0;
            animGat.SetBool("isClose", false);
        }
    }
}
