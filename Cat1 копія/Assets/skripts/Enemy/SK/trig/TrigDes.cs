using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrigDes : MonoBehaviour
{
    public GameObject Obj;

    private void OnTriggerEnter2D (Collider2D collision)
    {
        if(collision.tag == "skuiller")
        {
            Destroy(Obj);
        }
    }
}
