using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioTr : MonoBehaviour
{
    public float AudioAct;
    public GameObject Aud;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            Aud.SetActive(true);
            StartCoroutine(Audio());
        }
    }

    private IEnumerator Audio()
    {
        yield return new WaitForSeconds(AudioAct);
        Destroy(gameObject);
        

    }
}
