using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BosPilar : MonoBehaviour
{
    public Rigidbody2D[] rbStone;



    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            rbStone[0].isKinematic = false;
            rbStone[1].isKinematic = false;
        }
    }
}
