using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtLang : MonoBehaviour
{
    public void ButtUA()
    {
        languageMan.ENG = false;
        languageMan.UA = true;
    }

    public void ButtEng()
    {
        languageMan.ENG = true;
        languageMan.UA = false;
    }
}
