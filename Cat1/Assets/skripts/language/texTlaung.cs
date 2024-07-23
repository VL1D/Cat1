using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class texTlaung : MonoBehaviour
{
    public GameObject[] text;
    void Update()
    {
        if(languageMan.UA == true)
        {
            text[0].SetActive(true);
            text[1].SetActive(false);
        }
        else if(languageMan.ENG == true)
        {
            text[1].SetActive(true);
            text[0].SetActive(false);
        }

    }
}
