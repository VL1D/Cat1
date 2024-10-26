using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButterflyCat : MonoBehaviour
{

    private void Start()
    {
        if (MyPath == null)
        {
            return;
        }

        pointInPath = MyPath.GetNextPoints();

        pointInPath.MoveNext();

        if (pointInPath.Current == null)
        {
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
    public float speed;
    public float maxDistanct = .1f;

    private IEnumerator<Transform> pointInPath;
    private void FixedUpdate()
    {
        FielesFlyRandom();
    }


    public void FielesFlyRandom()
    {
        if (pointInPath == null || pointInPath.Current == null)
        {
            return;
        }

        if (Type == MovementType.Moveing)
        {
            transform.position = Vector3.MoveTowards(transform.position, pointInPath.Current.position, Time.deltaTime * speed);
        }
        else if (Type == MovementType.Leping)
        {
            transform.position = Vector3.Lerp(transform.position, pointInPath.Current.position, Time.deltaTime * speed);
        }

        var distanceSqure = (transform.position - pointInPath.Current.position).sqrMagnitude;
        if (distanceSqure < maxDistanct * maxDistanct)
        {
            pointInPath.MoveNext();
        }

    }
}

