using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
   public static LevelManager instance;

    public Transform[] respawnPointLevel;
    public GameObject[] LevelPrefab;
   // public Transform respawnPointLevel2;
    //public GameObject Level2Prefab;

    public void Awake()
    {
        instance = this; 
    }

    public void RespawnLevel2()
    {
        Instantiate(LevelPrefab[1], respawnPointLevel[1].position , Quaternion.identity);
    }

    public void RespawnLevel1()
    {
        Instantiate(LevelPrefab[0], respawnPointLevel[0].position, Quaternion.identity);
    }
}