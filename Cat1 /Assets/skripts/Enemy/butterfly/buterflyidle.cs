using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buterflyidle : MonoBehaviour
{
    public Animator anim;

    public bool fielsCircle;
    public bool fiels;
    public bool BoxFly;
    
    public Transform BoxPoint;
    public bool Fly_run;

    //public ParticleSystem patical;
    public GameObject patical;
    public bool part;

    private void Start()
    {
       if(MyPath == null)
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
        if (!BoxFly)
        {
            if (fiels)
            {
                FielesFlyRandom();
            }
            else
            {
                LadtFlay();
            }
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, BoxPoint.transform.position, 40f * Time.deltaTime);
            if(transform.position == BoxPoint.position)
            {
                anim.SetBool("fieles", true);
            }
        }
        if (Fly_run)
        {
            transform.Translate(Vector2.right * 40f * Time.deltaTime);
            transform.Translate(Vector2.up * 15f * Time.deltaTime);
            anim.SetBool("fieles", false);
        }
        if (part)
        {
            patical.SetActive(true);
        }
        else
        {
            patical.SetActive(false);
        }
    }

    
    public void FielesFlyRandom()
    {
        anim.SetBool("fieles", false);
        if(pointInPath == null || pointInPath.Current == null)
        {
            return;
        }

        if(Type == MovementType.Moveing)
        {
            transform.position = Vector3.MoveTowards(transform.position,pointInPath.Current.position,Time.deltaTime * speed);
        }
        else if(Type == MovementType.Leping)
        {
            transform.position = Vector3.Lerp(transform.position, pointInPath.Current.position, Time.deltaTime * speed);
        }

        var distanceSqure = (transform.position - pointInPath.Current.position).sqrMagnitude;
        if(distanceSqure < maxDistanct * maxDistanct)
        {
            pointInPath.MoveNext();
        }

    }

    public void LadtFlay()
    {
       anim.SetBool("fieles", true);
    }


    public void CutFieles()
    {
        fiels = true;
        BoxFly = false;
    }

}
