using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrows : MonoBehaviour
{
    public GameObject Respawn;
    public GameObject Menu;

    public void ArowsRL()
    {
        if (Respawn.activeSelf)
        {
            Menu.SetActive(true);
            Respawn.SetActive(false);
        }
        else
        {
            Menu.SetActive(false);
            Respawn.SetActive(true);
        }

    }

    

}
