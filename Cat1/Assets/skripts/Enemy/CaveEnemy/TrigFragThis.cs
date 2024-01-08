using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrigFragThis : MonoBehaviour 
{
    public CaveEnemyController caveEnemyController;
    public Transform pointsTr;
    public Transform points;

    //private void Start()
    //{
      //  caveEnemyController = GameObject.FindGameObjectWithTag("Enemy").GetComponent<CaveEnemyController>();
   // }
    private void FixedUpdate()
    {
        MoveC();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            caveEnemyController.activeMove = false;
            if (caveEnemyController.look == false)
            {
               caveEnemyController.speed = 60f;
               points.transform.position = pointsTr.position;

            }
        }
    }

    private void MoveC()
    {
        if (caveEnemyController.activeMove == false)
        {
            caveEnemyController.transform.position = Vector2.MoveTowards(caveEnemyController.transform.position, points.position, caveEnemyController.speed * Time.deltaTime);
            if (caveEnemyController.transform.position.x < points.position.x)
            {
                caveEnemyController.transform.eulerAngles = new Vector3(0, 180, 0);
            }
            else if (caveEnemyController.transform.position.x > points.position.x)
            {
                caveEnemyController.transform.eulerAngles = new Vector3(0, 0, 0);
            }
            if(caveEnemyController.transform.position.x == points.position.x)
            {
                caveEnemyController.speed = 0;
            }
        }
    }
}
