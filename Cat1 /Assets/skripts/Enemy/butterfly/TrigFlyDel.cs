using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrigFlyDel : MonoBehaviour
{
    public GameObject[] fly;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Fly")
        {
            Destroy(fly[0]);
            fly[1].SetActive(true);
            Destroy(gameObject, 1f);
        }
    }
}
