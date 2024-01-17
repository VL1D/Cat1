using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Gates : MonoBehaviour
{
    public float speed;
    public Transform Gat;
    public Animator animGat;
    public Transform poinsClose;

    public bool Open = false;
    
    private void FixedUpdate()
    {
        if (Open)
        {
            OpenGat();
            animGat.SetBool("isOpen", true);
            animGat.SetBool("isClose", false);
        }
        else
        {
            CloseGat();
            animGat.SetBool("isClose", true);
            animGat.SetBool("isOpen", false);
        }
        if (speed == 0)
        {
            animGat.SetBool("isClose", false);
            animGat.SetBool("isOpen", false);
        }
    }

    private void OpenGat()
    {
        transform.position = Vector2.MoveTowards(transform.position, poinsClose.transform.position, speed * Time.deltaTime);
        if (transform.position == poinsClose.transform.position)
        {
            speed = 0;
        }
    }

    private void CloseGat()
    {
        transform.position = Vector2.MoveTowards(transform.position, Gat.transform.position, speed * Time.deltaTime);
        if(transform.position == Gat.transform.position)
        {
            speed = 0;
        }
    }
}
