using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrigFragThis : MonoBehaviour 
{
    public CaveEnemyController CaveEnemyController;
    public GameObject CaveEnemy;
    public Transform points;
    private bool MoveCave = false;

    private void FixedUpdate()
    {
        if (MoveCave)
        {
            CaveEnemyController.transform.position = Vector2.MoveTowards(CaveEnemyController.transform.position, points.position, CaveEnemyController.speed * Time.deltaTime);
            if (CaveEnemyController.transform.position.x <= points.position.x)
            {
                CaveEnemyController.transform.eulerAngles = new Vector3(0, 180, 0);
            }
            else if (CaveEnemyController.transform.position.x >= points.position.x)
            {
                CaveEnemyController.transform.eulerAngles = new Vector3(0, 0, 0);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            CaveEnemyController.activeMove = false;
            MoveCave = true;
            CaveEnemyController.speed = 60f;
        }
    }
}
