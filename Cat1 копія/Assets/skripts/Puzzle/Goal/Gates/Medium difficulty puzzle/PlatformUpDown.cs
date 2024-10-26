using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformUpDown : MonoBehaviour
{
    public Animator anim;
    public float speed;
    private bool MoveUDPlatform;
    public GameObject Platform;
    public Transform[] pointsMovings;
    public bool PlatformMove;
    public GameObject aud;
    public GameObject[] audio;
    private bool StAud;
    public PlatformUpDown isLever;
    private bool not;
    public GameObject wh;
    public bool up;
    public bool down;


    private void Start()
    {
        speed = 0;
        StAud = true;
    }

    private void FixedUpdate()
    {
        PlatformMoving();
        if (not)
        {
            isLever.speed = 0;
            isLever.PlatformMove = false;
            if (up)
            {
                wh.transform.Rotate(0, 0, 100 * Time.deltaTime);
            }
            else if (down)
            {
                wh.transform.Rotate(0, 0, -100 * Time.deltaTime);
            }
            else
            {
                wh.transform.Rotate(0, 0, 0);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && !PlatformMove && !isLever.not)
        {
            aud.SetActive(true);
            speed = 10f;
            StAud = false;
            not = true;
            if (!MoveUDPlatform)
            {
                anim.SetBool("Lever", true);
                MoveUDPlatform = true;

            }
            else
            {
                anim.SetBool("Lever", false);
                MoveUDPlatform = false;
            }
        }

        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player" )
        {
            aud.SetActive(false);
        }


    }

    public void PlatformMoving()
    {
        if (!MoveUDPlatform && speed != 0f)
        {
            audio[0].SetActive(true);
            PlatformMove = true;
            down = true;
            up = false;
            Platform.transform.position = Vector2.MoveTowards(Platform.transform.position, pointsMovings[0].transform.position, speed * Time.deltaTime);
            if (Platform.transform.position == pointsMovings[0].transform.position)
            {
                speed = 0;
                not = false;
            }
        }
        else if(MoveUDPlatform && speed != 0f)
        {
            audio[0].SetActive(true);
            PlatformMove = true;
            up = true;
            down = false;
            Platform.transform.position = Vector2.MoveTowards(Platform.transform.position, pointsMovings[1].transform.position, speed * Time.deltaTime);
            if (Platform.transform.position == pointsMovings[1].transform.position)
            {
                speed = 0;
                not = false;
            }
        }

        if (speed == 0)
        {
            audio[0].SetActive(false);
            PlatformMove = false;
            down = false;
            up = false;
        }

        if (speed != 0f)
        {
            audio[1].SetActive(false);
        }
        else if (speed == 0f && !StAud)
        {
            audio[1].SetActive(true);
        }
    }
}
