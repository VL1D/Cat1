using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.ShaderData;

public class FlyRun : MonoBehaviour
{
    public buterflyidle fly;
    public float speedFly;
    public Transform pointTransform;

    public bool Run;

    void FixedUpdate()
    {
        if (!fly.BoxFly)
        {
            if (fly.fiels && Run)
            {
                transform.position = Vector2.MoveTowards(transform.position,pointTransform.position,speedFly * Time.deltaTime);
                if (transform.position == pointTransform.position)
                {
                    fly.transform.position = pointTransform.position;
                    transform.position = pointTransform.position;
                    fly.fiels = false;
                    Run = false;
                }
                if(transform.position.y < pointTransform.position.y)
                {
                    transform.Translate(Vector2.up * 20 * Time.deltaTime);
                }
            }
        }
    }
}
