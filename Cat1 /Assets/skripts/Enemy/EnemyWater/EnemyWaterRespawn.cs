using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWaterRespawn : MonoBehaviour
{
   public static EnemyWaterRespawn instance;

    public GameObject EnemyWater;
    public Transform RespawnEnemy;

    public Transform EnemWat;
    public GameObject SprayEnemy;

    public void Awake()
    {
        instance = this;
    }

    public void EnemyWatResp()
    {
        Instantiate(EnemyWater, RespawnEnemy.position, Quaternion.identity);
        Instantiate(SprayEnemy, EnemWat.position , Quaternion.identity);
        CutsceneManager.Instance.StartCutscene("CatSceneEnemyWater");
    }

}
