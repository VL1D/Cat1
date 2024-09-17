using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trigTreeDOWN : MonoBehaviour
{
    public Rigidbody2D rb;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            rb.isKinematic = false;
        }
    }
}
