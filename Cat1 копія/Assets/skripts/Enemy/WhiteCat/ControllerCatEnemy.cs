using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerCatEnemy : MonoBehaviour
{
    public static ControllerCatEnemy instance;

    public float speed;
    public float DistansRL;
    private Transform CatPoints;
    public bool Atack;
    public bool PrepAt;
    public bool StopAtackin;
    public bool DeatchEN;
    public Animator anim;
    private PlayerController player;
    public GameObject trigKill;
    public Rigidbody2D rb;
    public GameObject ButerFly;
    public Transform Cat;
    public GameObject EfectC;
    public GameObject Efectk;
    public GameObject audio;
    public GameObject aUDIOdEATCH;

    private void Start()
    {
        CatPoints = GameObject.FindGameObjectWithTag("Player").transform;
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        if(transform.position.x > CatPoints.position.x)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
        else if (transform.position.x < CatPoints.position.x)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
    }

    public void Awake()
    {
        instance = this;
    }

    private void FixedUpdate()
    {
        if (Atack)
        {
            AtackCat();
        }
        else 
        {
            StopAtack();
        }
        if (PrepAt)
        {
            anim.SetBool("startAt", true);
            EfectC.SetActive(true);
        }
        else
        {
            anim.SetBool("startAt", false);
            EfectC.SetActive(false);

        }
        if (player.Deatch)
        {
            gameObject.layer = 18;
            Atack = false;
            PrepAt = false;
        }
    }

    private void AtackCat()
    {
        anim.SetBool("atack", true);
        speed = 17f;
        transform.position = Vector2.Lerp(transform.position, CatPoints.position, Time.deltaTime * speed);
        audio.SetActive(true);
    }

    private void StopAtack()
    {
        anim.SetBool("atack", false);
        speed = 0f;
    }

    private void OnTriggerEnter2D (Collider2D collision)
    {
        if(collision.tag == "Player" )
        {
            Atack = false;
            StopAtackin = true;
            StartCoroutine(AtackStart());
            if (transform.eulerAngles.y == 0)
            {
                transform.eulerAngles = new Vector3(0, 180, 0);
                transform.position = new Vector2(transform.position.x + DistansRL, transform.position.y);
            }
            else if (transform.eulerAngles.y == 180)
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                transform.position = new Vector2(transform.position.x - DistansRL, transform.position.y);
            }
        }
        if(collision.tag == "RespEnemy")
        {
            trigKill.SetActive(false);
            anim.SetTrigger("Deatch");
            gameObject.layer = 31;
            //rb.isKinematic = true;
            Destroy(EfectC);
            DeatchEN = true;
        }
    }

    public void AnimAtack()
    {
        Atack = true;
        PrepAt = false;
    }

    public void Deatch()
    {
        Destroy(gameObject);
        Instantiate(ButerFly, Cat.position, Quaternion.identity);
        Instantiate(Efectk, Cat.position, Quaternion.identity);
        Instantiate(aUDIOdEATCH, Cat.position, Quaternion.identity);
    }

    public void AudioAt()
    {
        audio.SetActive(false);
    }

    private IEnumerator AtackStart()
    {
        yield return new WaitForSeconds(1.5f);
        StopAtackin = false;
    }
}