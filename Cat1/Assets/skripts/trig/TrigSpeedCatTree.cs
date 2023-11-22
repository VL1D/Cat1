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
            playercontroller.speed = 0;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            playercontroller.speed = 0;
            StartCoroutine(DeleteTrig());
        }
    }

    private IEnumerator DeleteTrig()
    {
        yield return new WaitForSeconds(1.5f);
        Destroy(gameObject);

    }
}
