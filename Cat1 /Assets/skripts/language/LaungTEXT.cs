using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaungTEXT : MonoBehaviour
{
    public GameObject[] text;

    // Update is called once per frame
    void Update()
    {
        if (LaungMan.UA)
        {
            text[0].SetActive(true);
            text[1].SetActive(false);
        }
        else if (LaungMan.ENG)
        {
            text[1].SetActive(true);
            text[0].SetActive(false);
        }
    }
}
