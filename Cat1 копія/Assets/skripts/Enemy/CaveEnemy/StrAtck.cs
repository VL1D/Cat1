using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class StrAtck : MonoBehaviour
{
    public float speed;

    private Transform Player;


    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void FixedUpdate()
    {
        transform.position = Vector2.MoveTowards(transform.position, Player.position, speed);
        if(Player.transform.position == transform.position)
        {
            Destroy(gameObject,0.1f);
        }
        if(transform.position.x < Player.position.x)
        {
            transform.eulerAngles = new Vector3(0,180,0);
        }
        else if (transform.position.x > Player.position.x)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
    }
}
