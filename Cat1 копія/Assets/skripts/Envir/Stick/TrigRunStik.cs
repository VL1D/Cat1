using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrigRunStik : MonoBehaviour
{
    public Animator animStik;
    public GameObject trig;
    public BoxCollider2D coll;
    public GameObject audio;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            animStik.SetTrigger("Run");
            Destroy(trig);
            Destroy(gameObject, 0.5f);
            coll.enabled = false;
            audio.SetActive(true);
        }
    }
}
