using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformLr : MonoBehaviour
{
    public Animator anim;
    public float speed;
    private bool MoveUDPlatform;
    public GameObject Platform;
    public Transform[] pointsMovings;
    public bool PlatformMove;
    public Animator PlatAnim;
    public bool move;

    private void FixedUpdate()
    {
        PlatformMoving();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && !PlatformMove)
        {
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

    public void PlatformMoving()
    {
        if (!MoveUDPlatform)
        {
            move = true;
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
            move = true;
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
            move = false;
            PlatformMove = false;
            PlatAnim.SetBool("up", false);
            PlatAnim.SetBool("down", false);
        }
    }
}
