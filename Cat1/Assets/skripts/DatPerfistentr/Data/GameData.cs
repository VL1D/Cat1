using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[System.Serializable]
public class GameData 
{
    public Vector3 playerPosition;
    public Vector3 WolfPosition;
    public Vector3 EarthPosition;

    public GameData()
    {
        playerPosition = Vector3.zero;
        WolfPosition = new Vector3(1014,52,0);
        EarthPosition = new Vector3(6882,28,0);
    }
}
