using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
   public static LevelManager instance;

    public Transform[] respawnPointLevel;
    public GameObject[] LevelPrefab;

    public void Start()
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
