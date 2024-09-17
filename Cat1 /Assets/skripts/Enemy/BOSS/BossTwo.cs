using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossTwo : MonoBehaviour
{
    public float speed;
    public bool run;
    public bool spawn;
    public Animator anim;
    public GameObject[] audio;
    void Update()
    {
        if (run)
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
            anim.SetBool("run", true);
            audio[0].SetActive(false);
        }
        else if (spawn)
        {
            speed = 0;
            anim.SetBool("run", false);
            anim.SetBool("Spawn", true);
        }
    }

    public void Brun()
    {
        run = true;
    }

    public void BSpan()
    {
        run = false;
        spawn = true;
    }

    public void RL()
    {
        speed = 40f;
        transform.eulerAngles = new Vector3(0, 180, 0);
        run = true;
    }

    public void trig()
    {
        anim.SetTrigger("RL");
    }

    public void AnimM()
    {
        audio[0].SetActive(true);
    }
}
