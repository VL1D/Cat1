using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrigFragThis : MonoBehaviour 
{
    public CaveEnemyController CaveEnemyController;
    public Transform pointsTr;
    public Transform points;

    private void FixedUpdate()
    {
        MoveC();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            CaveEnemyController.activeMove = false;
            CaveEnemyController.speed = 60f;
            points.transform.position = pointsTr.position;
        }
    }

    private void MoveC()
    {
        if (CaveEnemyController.activeMove == false)
        {
            CaveEnemyController.transform.position = Vector2.MoveTowards(CaveEnemyController.transform.position, points.position, CaveEnemyController.speed * Time.deltaTime);
            if (CaveEnemyController.transform.position.x < points.position.x)
            {
                CaveEnemyController.transform.eulerAngles = new Vector3(0, 180, 0);
            }
            else if (CaveEnemyController.transform.position.x > points.position.x)
            {
                CaveEnemyController.transform.eulerAngles = new Vector3(0, 0, 0);
            }
            if(CaveEnemyController.transform.position.x == points.position.x)
            {
                CaveEnemyController.speed = 0;
            }
        }
    }
}
