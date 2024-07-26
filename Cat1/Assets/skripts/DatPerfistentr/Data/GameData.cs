using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[System.Serializable]
public class GameData 
{
    public Vector3 playerPosition;
    public Dictionary<string, bool> tex;

    public GameData()
    {
        playerPosition = new Vector3(-3929, 58, 0);
        tex = new Dictionary<string, bool>();
    }

}
