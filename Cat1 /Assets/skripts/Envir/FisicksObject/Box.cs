using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class Box : MonoBehaviour
{
    public GameObject[] coll;
    private Rigidbody2D rb;
    public GameObject Audio;
    public GameObject AudioBox;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Water")
        {
            coll[0].SetActive(false);
            coll[1].SetActive(true);
            gameObject.layer = 7;
            Audio.SetActive(true);
        }

        if (collision.tag == "BoxTrig")
        {
            
            AudioBox.SetActive(true);
        }
    }
}
