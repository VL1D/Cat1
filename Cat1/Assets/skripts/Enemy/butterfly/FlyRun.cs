using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.ShaderData;

public class FlyRun : MonoBehaviour
{
    public buterflyidle fly;
    public float speedFly;
   // public Transform[] pointTransform;

    public bool Run;

    private void Start()
    {
        if (MyPath == null)
        {
            Debug.Log("Примени путь");
            return;
        }

        pointInPath = MyPath.GetNextPoints();

        pointInPath.MoveNext();

        if (pointInPath.Current == null)
        {
            Debug.Log("потрібні точки");
            return;
        }

        transform.position = pointInPath.Current.position;
    }

    public enum MovementType
    {
        Moveing,
        Leping
    }

    public MovementType Type = MovementType.Moveing;
    public MovemingPoins MyPath;
    //public float speed;
    public float maxDistanct = .1f;
    private IEnumerator<Transform> pointInPath;

    void FixedUpdate()
    {
        if (!fly.BoxFly)
        {
            if (fly.fiels && Run)
            {
                if (pointInPath == null || pointInPath.Current == null)
                {
                    return;
                }

                if (Type == MovementType.Moveing)
                {
                    transform.position = Vector3.MoveTowards(transform.position, pointInPath.Current.position, Time.deltaTime * speedFly);
                }
                else if (Type == MovementType.Leping)
                {
                    transform.position = Vector3.Lerp(transform.position, pointInPath.Current.position, Time.deltaTime * speedFly);
                }

                var distanceSqure = (transform.position - pointInPath.Current.position).sqrMagnitude;
                if (distanceSqure < maxDistanct * maxDistanct)
                {
                    pointInPath.MoveNext();
                }
            }
        }
    }
}
