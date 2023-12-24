using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterBox : MonoBehaviour
{
    public static WaterBox instance;

    public GameObject[] Spray;
    public Transform[] posBox;

    public void Awake()
    {
        instance = this;
    }

    public void RespawnStay()
    {
        Instantiate(Spray[0], posBox[0].position, Quaternion.identity);
        Instantiate(Spray[1], posBox[1].position, Quaternion.identity);
    }
}
