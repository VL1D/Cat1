using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MurCat : MonoBehaviour
{
    public GameObject Cat;
    void Update()
    {
        transform.position = Cat.transform.position;
    }
}
