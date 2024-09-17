using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class activator : MonoBehaviour
{
    public GameObject enemyWat;

    private void OnTriggerStay2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            enemyWat.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            enemyWat.SetActive(false);
        }
    }
}
