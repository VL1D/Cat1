using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrigLever : MonoBehaviour
{
    public Animator anim;
    public Animator animGating;
    public Animator Gat;
    public bool Blocking ;
    public GameObject Gattes;
    public Transform[] pointsGatt;
    public float speedGatt;
    public GameObject trigResp;

    private void FixedUpdate()
    {
        LeverGates();
    }

    public void LeverGates()
    {
        if (!Blocking)
        {
            Gattes.transform.position = Vector2.MoveTowards(Gattes.transform.position, pointsGatt[0].transform.position, speedGatt * Time.deltaTime);
            if (Gattes.transform.position == pointsGatt[0].transform.position)
            {
                speedGatt = 0;
            }
            animGating.SetBool("isOpen", true);
            animGating.SetBool("isClose", false);
            Gat.SetBool("isOpen", true);
            Gat.SetBool("isClose", false);
            trigResp.SetActive(false);
        }
        else
        {
            Gattes.transform.position = Vector2.MoveTowards(Gattes.transform.position, pointsGatt[1].transform.position, speedGatt * Time.deltaTime);
            if (Gattes.transform.position == pointsGatt[1].transform.position)
            {
                speedGatt = 0;
            }
            animGating.SetBool("isClose", true);
            animGating.SetBool("isOpen", false);
            trigResp.SetActive(true);
            Gat.SetBool("isOpen", false);
            Gat.SetBool("isClose", true);
        }

        if (speedGatt == 0)
        {
            animGating.SetBool("isClose", false);
            animGating.SetBool("isOpen", false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            speedGatt = 13f;
            if (!Blocking)
            {
                Blocking = true;
                anim.SetBool("Lever", true);

            }
            else
            {
                Blocking = false;
                anim.SetBool("Lever", false);
            }
        }
    }
}
