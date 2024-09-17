using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trigNoAc : MonoBehaviour
{
    public GameObject[] obj;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            obj[0].SetActive(false);
            obj[1].SetActive(false);
            obj[2].SetActive(false);
        }
    }
}
