using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrigAtacEnemy : MonoBehaviour
{
    public CaveEnemyController Enemycontroller;

    public Transform[] str;
    public Transform[] strAtack;

    public PlayerController PlayerController;

    public GameObject strg;

    private bool AtackEnemy = false;

    private void FixedUpdate()
    {
        if (AtackEnemy)
        {
            AnimAtack();
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Enemycontroller.anim.SetTrigger("Atack");
            AtackEnemy = true;
            PlayerController.speed = 0f;
            PlayerController.normalSpeed = 0f;
        }
    }
    public void AnimAtack()
    {
        str[0].transform.position = strAtack[0].position;
        str[1].transform.position = strAtack[1].position;
        strg.SetActive(true);
    }

}
