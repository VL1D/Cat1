using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound : MonoBehaviour
{
    public  AudioClip Soundtreck;
    void Start()
    {
        AudioManager.instance.PlaySound(Soundtreck);
    }

  
}
