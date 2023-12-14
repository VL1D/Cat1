using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrigWater : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.tag == "Player" )
        {
            Water.instance.RespawnStay();
        }
        if (collider.tag == "Box") 
        {
            WaterBox.instance.RespawnStay();
        }

    }
}
