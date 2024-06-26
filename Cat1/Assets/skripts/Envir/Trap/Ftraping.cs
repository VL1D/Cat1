using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ftraping :  Trap
{
    public Rigidbody2D rbStone;
    public GameObject audio;

    void Start()
    {
        rbStone = GetComponent<Rigidbody2D>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            rbStone.isKinematic = false;
            audio.SetActive(true);
            Destroy(audio, 1.3f);
        }
    }
}
