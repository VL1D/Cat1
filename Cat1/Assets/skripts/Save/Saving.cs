using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saving : MonoBehaviour
{
    public PlayerController Controller;
    
    public void Loading()
    {
        Controller.LodPlayer();
    }
}
