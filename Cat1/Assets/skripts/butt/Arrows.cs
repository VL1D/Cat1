using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrows : MonoBehaviour
{
    public GameObject Respawn;
    public GameObject Menu;

    public void ArowsR()
    {
        if (Respawn.activeSelf )
        {
            Menu.SetActive(true);
            Respawn.SetActive(false);
        }

    }

    public void ArowsL()
    {
        if ( !Respawn.activeSelf)
        {
            Menu.SetActive(false);
            Respawn.SetActive(true);
        }
    }

}
