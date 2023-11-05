using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour
{
    public GameObject coll1;
    public GameObject coll2;

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            coll1.SetActive(false);
            coll2.SetActive(true);
        }
    }
}
