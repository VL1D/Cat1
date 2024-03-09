using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrigNoDOWN : MonoBehaviour
{
    public buterflyidle fly;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.tag == "Fly")
        {
            fly.fiels = true;
        }
    }
}
