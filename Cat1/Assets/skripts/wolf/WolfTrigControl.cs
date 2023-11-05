using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolfTrigControl : MonoBehaviour
{
    public Animator Wolf;
    public Animator Wolfone;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            Wolf.Play("hofl");
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        Wolfone.Play("hofl");
    }
}
