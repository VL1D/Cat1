using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.ShaderData;

public class FlyRun : MonoBehaviour
{
    public buterflyidle fly;
    public float speedFly;

    void FixedUpdate()
    {
        if (!fly.BoxFly)
        {
            if (fly.fiels)
            {
                transform.Translate(Vector2.right * speedFly * Time.deltaTime);
                if (fly.GrounCheck)
                {
                    transform.Translate(Vector2.up * fly.speed * Time.deltaTime);
                }
            }
            else
            {
                transform.Translate(Vector2.right * 0 * Time.deltaTime);
            }
        }
    }
}
