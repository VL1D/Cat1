using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{
    public float speed;

    public bool MR;
    public bool LR;
    public bool turn_RL;
    public bool turn_LR;
    public bool stanR;
    public bool stanL;
    public bool SpawnR;
    public bool SpawnL;

    public bool End;

    public Animator anim;
    public Animat[] glow;

    public GameObject[] Trig;

    public Transform[] pointResp;
    public GameObject RESP;
    public GameObject ef;

    public BosPilar PillarContr;

    void Start()
    {
        MR = true;
    }

    void FixedUpdate()
    {
        if (!End)
        {
            if (!turn_LR && !turn_RL && !stanR && !stanL)
            {
                if (MR && !LR && !SpawnL && !SpawnR)
                {
                    MoveR();
                }
                else if (!MR && LR && !SpawnL && !SpawnR)
                {
                    MoveL();
                }
            }
        }
        if (stanL)
        {
            anim.SetTrigger("stanR");
        }
        else if (stanR)
        {
            anim.SetTrigger("stanL");
        }
    }

    public void MoveR()
    {
        anim.SetBool("runR", true);
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    public void MoveL()
    {
        anim.SetBool("runL", true);
        transform.Translate(Vector2.left * speed * Time.deltaTime);
    }


    public void TurnRL()
    {
        transform.eulerAngles = new Vector3(0, 0, 0);
        turn_RL = false;
        turn_LR = false;
        stanL = true;
    }

    public void TurnLR()
    {
        transform.eulerAngles = new Vector3(0, 0, 0);
        turn_LR = false;
        turn_RL = false;
        stanR = true;
    }

    public void NoStanL()
    {
        if (!End)
        {
            speed = 15f;
            stanL = false;
            stanR = false;
            turn_LR = false;
            turn_RL = false;
            LR = true;
            Trig[1].SetActive(true);
        }
    }

    public void NoStanR()
    {
        if (!End)
        {
            speed = 15f;
            stanR = false;
            stanL = false;
            turn_LR = false;
            turn_RL = false;
            MR = true;
            Trig[0].SetActive(true);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void GlowAkt()
    {
        if (!End)
        {
            glow[0].ACT = true;
            glow[0].speed = 0f;
            glow[1].ACT = true;
            glow[1].speed = 0f;
            glow[2].ACT = true;
            glow[2].speed = 0f;
        }
    }

    public void StartAnimSL()
    {
        anim.Play("SpawnL");
    }

    public void StartAnimSR()
    {
        anim.Play("SpawnR");
    }

    public void RespR()
    {
        Instantiate(RESP, pointResp[0].position, Quaternion.identity);
    }

    public void RespL()
    {
        Instantiate(RESP, pointResp[1].position, Quaternion.identity);
    }

    public void AnimEnd()
    {
        if (End)
        {
            ef.SetActive(true);
            PillarContr.EndBoos = true;
        }
    }


    
}
