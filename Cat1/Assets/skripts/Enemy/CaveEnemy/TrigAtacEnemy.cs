using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrigAtacEnemy : MonoBehaviour
{
    public CaveEnemyController Enemycontroller;

    public PlayerController PlayerController;

    public GameObject Cat;
    public GameObject CaveEnemy;


   
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player" && PlayerController.hidden == false)
        {
            Enemycontroller.anim.SetTrigger("Atack");
            Enemycontroller.AtackEnemy = true;
            PlayerController.speed = 0f;
            PlayerController.normalSpeed = 0f;
            Enemycontroller.speed = 0f;
            Enemycontroller.activeMove = false;
            if (Cat.transform.position.x > CaveEnemy.transform.position.x)
            {
                CaveEnemy.transform.eulerAngles = new Vector3(0, 180, 0);
            }
            else if (Cat.transform.position.x < CaveEnemy.transform.position.x)
            {
                CaveEnemy.transform.eulerAngles = new Vector3(0, 0, 0);
            }
        }
    }
    

}
