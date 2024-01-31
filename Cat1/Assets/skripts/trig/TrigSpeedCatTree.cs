using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrigSpeedCatTree : MonoBehaviour
{
    public PlayerController playercontroller;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (playercontroller.transform.eulerAngles.y == 180)
            {
                playercontroller.transform.eulerAngles = new Vector3(0, 0, 0);
            }
            playercontroller.normalSpeed = 0;
            playercontroller.speed = 0;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            //playercontroller.speed = 0;
            Destroy(gameObject,1.7f);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            playercontroller.normalSpeed = 40;
        }
    }
}
