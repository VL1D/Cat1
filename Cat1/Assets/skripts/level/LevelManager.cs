using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
   public static LevelManager instance;

    public Transform respawnPointLevel1;
    public GameObject Level1Prefab;
    public Transform respawnPointLevel2;
    public GameObject Level2Prefab;

    public void Awake()
    {
        instance = this; 
    }

    public void RespawnLevel2()
    {
        Instantiate(Level2Prefab, respawnPointLevel2.position , Quaternion.identity);
    }

    public void RespawnLevel1()
    {
        Instantiate(Level1Prefab, respawnPointLevel1.position, Quaternion.identity);
    }
}
