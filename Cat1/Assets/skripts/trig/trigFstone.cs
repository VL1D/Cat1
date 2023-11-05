using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trigFstone : MonoBehaviour
{


    Rigidbody2D rbStone;


    void Start()
    {
        rbStone = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            rbStone.isKinematic = false;

        }
    }

}
