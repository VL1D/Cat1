using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrigLevel2 : MonoBehaviour
{
    public GameObject[] level;
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            Destroy(level[2]);
            Destroy(level[1]);
            Destroy(level[3]);
            Destroy(level[4]);
        }
    }
}
