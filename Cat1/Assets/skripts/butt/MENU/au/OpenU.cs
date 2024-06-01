using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenU : MonoBehaviour
{
    public string stURL;

    public void OpenSsil()
    {
        Application.OpenURL(stURL);
    }
}
