using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossTwo : MonoBehaviour
{
    public float speed;
    public bool run;
    public bool spawn;
    public Animator anim;
    void Update()
    {
        if (run)
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
            anim.SetBool("run", true);
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
}
