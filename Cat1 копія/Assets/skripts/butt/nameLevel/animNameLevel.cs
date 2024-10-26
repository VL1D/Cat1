using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animNameLevel : MonoBehaviour
{
    public GameObject levelN;

    public GameObject ef;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            levelN.SetActive(true);
        }
    }

    public void AnimStart()
    {
        ef.SetActive(true);
    }

    public void AnimEnd()
    {
        Destroy(gameObject, 2f);
    }
}
