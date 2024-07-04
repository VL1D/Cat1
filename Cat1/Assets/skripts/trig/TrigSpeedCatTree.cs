using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrigSpeedCatTree : MonoBehaviour
{
    public GameObject coll;


    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            coll.SetActive(true);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Destroy(gameObject, 3f);
            Destroy(coll, 3f);
        }
    }

}
