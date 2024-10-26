using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrigAtack : MonoBehaviour
{
    public ControllerEnemyWater enemyWater;
    public GameObject Enemy;
    public GameObject TrigDeatch;
    public Animator animEnemy;
    public GameObject Audio;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Audio.SetActive(true);
            enemyWater.speed = 0;
            animEnemy.SetTrigger("Atack");
            Enemy.SetActive(true);
            StartCoroutine(ActiveRest());
        }
    }

    private IEnumerator ActiveRest()
    {
        yield return new WaitForSeconds(0.2f);
        TrigDeatch.SetActive(true);
    }
}
