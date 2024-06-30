using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformUPRL : MonoBehaviour
{
    public Animator anim;
    public float speed;
    private bool MoveUDPlatform;
    public GameObject Platform;
    public Transform[] pointsMovings;
    public bool PlatformMove;
    public Animator PlatAnim;
    public PlatformLr PlatformLever;
    public GameObject aud;
    public GameObject[] audio;
    private bool StAud;

    private void Start()
    {
        speed = 0;
        StAud = true;
    }

    private void FixedUpdate()
    {
        PlatformMoving();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && !PlatformMove)
        {
            StAud = false;
            aud.SetActive(true);
            speed = 10f;
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
        if (collision.tag == "Player")
        {
            aud.SetActive(false);
        }
    }

    public void PlatformMoving()
    {
        if (!PlatformLever.move)
        {
            if (MoveUDPlatform)
            {
                audio[0].SetActive(true);
                PlatformMove = true;
                PlatAnim.SetBool("up", true);
                Platform.transform.position = Vector2.MoveTowards(Platform.transform.position, pointsMovings[0].transform.position, speed * Time.deltaTime);
                if (Platform.transform.position == pointsMovings[0].transform.position)
                {
                    speed = 0;
                }
            }
            else
            {
                audio[0].SetActive(true);
                PlatformMove = true;
                PlatAnim.SetBool("down", true);
                Platform.transform.position = Vector2.MoveTowards(Platform.transform.position, pointsMovings[1].transform.position, speed * Time.deltaTime);
                if (Platform.transform.position == pointsMovings[1].transform.position)
                {
                    speed = 0;
                }
            }

            if (speed == 0)
            {
                audio[0].SetActive(false);
                PlatformMove = false;
                PlatAnim.SetBool("up", false);
                PlatAnim.SetBool("down", false);
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
}
