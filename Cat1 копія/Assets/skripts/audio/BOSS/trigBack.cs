using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trigBack : MonoBehaviour
{
    public GameObject backAudio;
    //public Sound manag;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            backAudio.SetActive(true);
            Sound.instance.NoAc();
        }
    }
}
