using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trigDestroy : MonoBehaviour
{
    public GameObject[] DestObj;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            Destroy(DestObj[0]);
            Destroy(DestObj[1]);
        }
    }
}
