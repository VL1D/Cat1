using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrigWolfAtack : MonoBehaviour
{
    public WolfController WolfController;
    public GameObject TrigWolf;
    public PlayerController controller;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player" )
        {
            WolfController.speed = 0f;
            WolfController.anim.SetBool("atack",true);
            TrigWolf.SetActive(true);
            controller.speed = 0f;
        }
    }
   
}
