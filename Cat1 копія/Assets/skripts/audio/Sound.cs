using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound : AudioManager
{
    public static Sound instance = null;

    public Animator anim;
    private void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            DestroyAudio();
        }
        PlaySoynd(soundAudio[0]);
        DontDestroyOnLoad(gameObject);
    }


    public void DestroyAudio()
    {
        Destroy(gameObject);
    }

    public void NoAc()
    {
        anim.SetBool("Noactive", true);
    }

    public void Ac()
    {
        anim.SetBool("Noactive", false);
    }

}
