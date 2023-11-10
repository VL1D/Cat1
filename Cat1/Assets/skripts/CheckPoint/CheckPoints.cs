using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoints : MonoBehaviour
{
    public Transform player;
    public int index;
    void Awake()
    {
        player = GameObject.Find("Cat").transform;
        if (DataCheck.checkPointIndex == index)
        {

            player.position = transform.position;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (index > DataCheck.checkPointIndex)
            {
                DataCheck.checkPointIndex = index;
            }
        }
    }
}
