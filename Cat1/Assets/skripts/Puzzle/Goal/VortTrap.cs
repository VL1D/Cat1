using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VortTrap : MonoBehaviour
{
    public Gates[] gates;
    public bool OpenBut = false;
    public float speed;
    public Transform ButPoints;

    private void FixedUpdate()
    {
        if (OpenBut)
        {
            if (transform.position.y > ButPoints.transform.position.y)
            {
                transform.Translate(Vector2.down * speed * Time.deltaTime);
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player" )
        {
            OpenBut = true;
            gates[0].speed = 30f;
            gates[1].Open = false;
            gates[0].Open = false;
            gates[1].speed = 30f;
            speed = 10f;
        }
    }
}
