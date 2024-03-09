using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrigFlyDown : MonoBehaviour
{
    public buterflyidle fly;
    public FlyRun FlyRun;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.tag == "Fly")
        {
            FlyRun.transform.Translate(Vector2.down * 15f * Time.deltaTime);
        }
    }
}
