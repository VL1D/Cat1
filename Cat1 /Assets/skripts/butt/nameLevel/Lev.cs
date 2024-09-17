using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lev : MonoBehaviour
{
    public GameObject ef;
    public GameObject Gl;
    public void AnimStart()
    {
        ef.SetActive(true);
    }

    public void AnimEnd()
    {
        Destroy(Gl, 2f);
    }
}
