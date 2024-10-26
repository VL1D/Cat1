using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trigJum : MonoBehaviour
{

    public WolfController wolf;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            wolf.CatClose = true;
            wolf.GroundDop = false;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            wolf.CatClose = false;
        }
    }
}
