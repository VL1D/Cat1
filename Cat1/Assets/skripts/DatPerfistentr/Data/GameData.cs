using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[System.Serializable]
public class GameData 
{
    public Vector3 playerPosition;

    public GameData()
    {
        playerPosition = new Vector3(-3917, 58, 0);
    }
}
