using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrigFly : MonoBehaviour
{
    public buterflyidle fly;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            fly.fiels = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            fly.fiels = false;
        }
    }
}
