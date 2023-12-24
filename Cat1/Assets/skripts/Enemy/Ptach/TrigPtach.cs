using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrigPtach : MonoBehaviour
{
    public Ptach ptach;
    public Animator animPtach;

    public GameObject Ptach;
    private IEnumerator PtachDestr()
    {
        yield return new WaitForSeconds(3f);
        Destroy(gameObject);

    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            ptach.speed = 0f;
            ptach.flightSpeed = 0.5f;
            Ptach.transform.position += Ptach.transform.up * 0.1f;
            Ptach.transform.position += Ptach.transform.right * 0.1f ;
            animPtach.SetBool("isFky", true);
             
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

