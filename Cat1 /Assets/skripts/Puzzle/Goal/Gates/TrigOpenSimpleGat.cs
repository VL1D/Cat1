using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrigOpenSimpleGat : MonoBehaviour
{
    public float speedGatt;
    public GameObject Gattes;
    public Transform[] pointsGatt;
    private bool GattesOpen;
    public Animator anim;
    public GameObject trigResp;
    public GameObject[] audio;
    private bool StAud;
    private void Start()
    {
        speedGatt = 0;
        StAud = true;
    }
    private void FixedUpdate()
    {
        PressButt();
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            GattesOpen = true;
            speedGatt = 8f;
            StAud = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            speedGatt = 13f;
            GattesOpen = false;
            StAud = false;
        }
    }

    public void PressButt()
    {
        if (GattesOpen)
        {
            audio[0].SetActive(true);
            Gattes.transform.position = Vector2.MoveTowards(Gattes.transform.position, pointsGatt[0].transform.position, speedGatt * Time.deltaTime);
            if (Gattes.transform.position == pointsGatt[0].transform.position)
            {
                speedGatt = 0;
            }
            anim.SetBool("isOpen", true);
            anim.SetBool("isClose", false);
            trigResp.SetActive(false);
        }
        else
        {
            audio[0].SetActive(true);
            Gattes.transform.position = Vector2.MoveTowards(Gattes.transform.position, pointsGatt[1].transform.position, speedGatt * Time.deltaTime);
            if (Gattes.transform.position == pointsGatt[1].transform.position)
            {
                speedGatt = 0;
            }
            anim.SetBool("isClose", true);
            anim.SetBool("isOpen", false);
            trigResp.SetActive(true);
        }

        if (speedGatt == 0)
        {
            audio[0].SetActive(false);
            anim.SetBool("isClose", false);
            anim.SetBool("isOpen", false);
        }

        if(speedGatt != 0f)
        {
            audio[1].SetActive(false);
        }
        else if(speedGatt == 0f && !StAud)
        {
            audio[1].SetActive(true);
        }
    }
}
