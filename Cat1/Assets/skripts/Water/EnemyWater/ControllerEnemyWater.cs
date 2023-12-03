using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerEnemyWater : MonoBehaviour
{
    public PlayerController playerController;

    public float speed;

    private Animator anim;
    private Rigidbody2D rb;

    public Transform CatPos;

    private void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        if (playerController.isWater)
        {
            StartHunting();
        }
        else
        {
            StoptHunting();
        }
    }

    private void StartHunting()
    {
        if(CatPos.position.x < transform.position.x)
        {
            rb.velocity = new Vector2 (-speed, 0);
        }
        else if (CatPos.position.x > transform.position.x)
        {
            rb.velocity = new Vector2(speed, 0);
        }
    }
    private void StoptHunting()
    {
        rb.velocity = Vector2.zero;
    }
}
