using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWaterRespawn : MonoBehaviour
{
   public static EnemyWaterRespawn instance;

    public GameObject EnemyWater;
    public Transform RespawnEnemy;

    public void Awake()
    {
        instance = this;
    }

    public void EnemyWatResp()
    {
        Instantiate(EnemyWater, RespawnEnemy.position, Quaternion.identity);
        CutsceneManager.Instance.StartCutscene("CatScene1");
    }

}
