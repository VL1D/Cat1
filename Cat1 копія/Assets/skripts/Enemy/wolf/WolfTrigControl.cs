using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolfTrigControl : MonoBehaviour
{
    public Animator Wolf;
    public Animator Wolfone;
    public GameObject[] audio;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            Wolf.Play("hofl");
            audio[0].SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Wolfone.Play("hofl");
            audio[1].SetActive(true);
        }
    }
}
