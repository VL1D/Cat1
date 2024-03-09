using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrigFly : MonoBehaviour
{
    public buterflyidle fly;
    public FlyRun FlyRun;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            fly.fiels = true;
            FlyRun.Run = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            fly.fiels = false;
            FlyRun.Run = false;
        }
    }
}
