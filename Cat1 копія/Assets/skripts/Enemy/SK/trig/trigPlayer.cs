using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trigPlayer : MonoBehaviour
{
    public Skuiller skull;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            skull.Run = true;
        }
    }
}
