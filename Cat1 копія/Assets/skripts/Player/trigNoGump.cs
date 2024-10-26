using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trigNoGump : MonoBehaviour
{
    public PlayerController player;

    private void OnTriggerStay2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            player.jumpTr = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            player.jumpTr = false;
        }
    }
}
