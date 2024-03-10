using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovemingPoins : MonoBehaviour
{
    public enum PathTypes
    {
        lineor,
        loop
    }

    public PathTypes PathType;
    public int movementDirection = 1;
    public int moveingTo = 0;
    public Transform[] points;

    public void OnDrawGizmos()
    {
        if (points == null || points.Length < 2)
        {
            return;
        }

        for (var i = 1; i < points.Length; i++)
        {
            Gizmos.DrawLine(points[i - 1].position, points[i].position);
        }

        if (PathType == PathTypes.loop)
        {
            Gizmos.DrawLine(points[0].position, points[points.Length - 1].position);
        }
    }

    public IEnumerator<Transform> GetNextPoints()
    {
        if (points == null || points.Length < 1)
        {
            yield break;
        }

        while (true)
        {
            yield return points[moveingTo];

            if (points.Length == 1)
            {
                continue;
            }

            if (PathType == PathTypes.lineor)
            {
                if (moveingTo <= 0)
                {
                    movementDirection = 1;
                }
                else if (moveingTo >= points.Length - 1)
                {
                    movementDirection = -1;
                }
            }

            moveingTo = moveingTo + movementDirection;

            if (PathType == PathTypes.loop)
            {
                if (moveingTo >= points.Length)
                {
                    moveingTo = 0;
                }

                if (moveingTo < 0)
                {
                    moveingTo = points.Length - 1;
                }
            }
        }
    }

}
