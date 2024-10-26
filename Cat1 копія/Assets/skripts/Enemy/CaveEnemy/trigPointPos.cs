using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trigPointPos : MonoBehaviour
{
    public Transform pointsTr;
    public Transform points;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            points.transform.position = pointsTr.position;
        }
    }
}
