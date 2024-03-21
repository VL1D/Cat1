using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Whel : MonoBehaviour
{
    public GameObject whel;
    public bool up;
    public bool down;

    private void FixedUpdate()
    {
        if (up)
        {
            whel.transform.Rotate(0, 0, 100 * Time.deltaTime);
        }
        else if (down)
        {
            whel.transform.Rotate(0, 0, -100 * Time.deltaTime);
        }
        else
        {
            whel.transform.Rotate(0, 0, 0);
        }
    }
}
