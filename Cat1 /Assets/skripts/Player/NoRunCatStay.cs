using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoRunCatStay : MonoBehaviour
{
    public GameObject COLL;


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Destroy(gameObject, 3f);
            Destroy(COLL, 3f);
        }
    }

}
