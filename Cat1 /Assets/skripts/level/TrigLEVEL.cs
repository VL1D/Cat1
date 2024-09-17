using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrigLEVEL : MonoBehaviour
{
    public Animator animLevel;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            animLevel.SetTrigger("Dell");
        }
    }
}
