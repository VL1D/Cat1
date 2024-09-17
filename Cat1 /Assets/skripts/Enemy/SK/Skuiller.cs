using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skuiller : MonoBehaviour
{
    public float speed;

    public bool Run;
    public bool Jump;
    public bool Deatch;
    private Rigidbody2D rb;

    public Animator anim;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
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
    public float maxDistanct = .1f;
    private IEnumerator<Transform> pointInPath;

    void FixedUpdate()
    {
        if (!Deatch)
        {
            if (Run)
            {
                anim.SetBool("Run", true);
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
            else
            {
                anim.SetBool("Run", false);
            }

            if (Jump)
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
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Respawn")
        {
            speed = 0f;
            anim.SetTrigger("Deatch");
            Deatch = true;
            transform.eulerAngles = new Vector3(0, 180, 0);
            rb.isKinematic = false;
            Destroy(gameObject, 2f);
        }
    }

    public void RunCut()
    {
        Run = true;
    }
}
