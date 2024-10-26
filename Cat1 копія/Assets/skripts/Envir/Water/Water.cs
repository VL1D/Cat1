using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{

    public static Water instance;

    public GameObject Spray;
    public Transform Cat;

    public void Awake()
    {
        instance = this;
    }

    public void RespawnStay()
    {
        Instantiate(Spray, Cat.position, Quaternion.identity);
    }
    
}
