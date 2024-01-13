using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtGates : MonoBehaviour
{
    public Gates[] gates;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            gates[0].speed = 8f;
            gates[1].speed = 8f;
            gates[0].Open = true;
            gates[1].Open = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            gates[0].speed = 3f;
            gates[1].speed = 3f;
            gates[0].Open = false;
            gates[1].Open = false;
        }
    }
}
