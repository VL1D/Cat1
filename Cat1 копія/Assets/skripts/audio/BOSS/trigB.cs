using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trigB : MonoBehaviour
{
    public GameObject bossM;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            bossM.SetActive(true);
        }
    }
}
