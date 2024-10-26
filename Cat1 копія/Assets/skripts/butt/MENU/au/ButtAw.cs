using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtAw : MonoBehaviour
{
    public GameObject[] obj;

    public void OpenClose()
    {
        obj[0].SetActive(true);
        obj[1].SetActive(false);
    }
}
