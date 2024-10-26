using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FSaudio : MonoBehaviour
{
    public GameObject Audio;
    public Rigidbody2D rb;
    private void OnTriggerEnter2D (Collider2D collision)
    {
        if(collision.tag == "DestrSt")
        {
            if(rb.isKinematic == false)
            {
                Audio.SetActive(true);
            }
        }
    }
}
