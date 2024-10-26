using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class load : MonoBehaviour
{
    public NewGame newG;

    public void Cont()
    {
        newG.ContineGame();
        //gameObject.SetActive(false);
    }

    public void NEw()
    {
        newG.StartNewGame();
        //gameObject.SetActive(false);
    }
}
