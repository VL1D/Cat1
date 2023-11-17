using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData 
{
    public Vector3 playerPosition;
    public Vector3 WolfPosition;
     
    public GameData()
    {
        playerPosition = Vector3.zero;
        WolfPosition = new Vector3(1014,52,0);
    }
}
