using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PointsTrig : MonoBehaviour
{
    public FlyRun FlyRun;
    public buterflyidle fly;
    public GameObject[] Fly;
    public Transform points;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Fly" )
        {
            fly.fiels = false;
            FlyRun.Run = false;
            Fly[0].transform.position = points.position;
            Fly[1].transform.position = points.position;
        }

        
    }

   
}
