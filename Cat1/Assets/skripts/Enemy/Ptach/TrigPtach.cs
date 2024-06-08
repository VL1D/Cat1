using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrigPtach : MonoBehaviour
{
    public Ptach ptach;
    public Animator animPtach;

    public GameObject Ptach;
    public GameObject part;

    public GameObject audio;
    private IEnumerator PtachDestr()
    {
        yield return new WaitForSeconds(3f);
        Destroy(gameObject);

    }
    private void Start()
    {
        part.SetActive(false);
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            audio.SetActive(true);
            ptach.speed = 0f;
            ptach.flightSpeed = 0.5f;
            Ptach.transform.position += Ptach.transform.up * 0.1f;
            Ptach.transform.position += Ptach.transform.right * 0.1f ;
            animPtach.SetBool("isFky", true);
            part.SetActive(true);
             
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            StartCoroutine(PtachDestr());
        }
    }
}

