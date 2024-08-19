using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunButt : MonoBehaviour
{
    public void ButENG()
    {
        LaungMan.ENG = true;
        LaungMan.UA = false;
    }

    public void ButUA()
    {
        LaungMan.ENG = false;
        LaungMan.UA = true;
    }
}
