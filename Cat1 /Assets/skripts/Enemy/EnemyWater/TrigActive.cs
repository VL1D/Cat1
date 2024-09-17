using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrigActive : MonoBehaviour
{
    public GameObject[] Enemy;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Enemy[0].SetActive(true);
            Enemy[1].SetActive(false);
        }
    }



}
