using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButterflyEbd : MonoBehaviour
{
    public float destoySpeed;
    void Start()
    {
        Destroy(gameObject, destoySpeed);
    }
}
