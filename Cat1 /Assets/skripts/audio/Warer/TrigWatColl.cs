using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrigWatColl : MonoBehaviour
{
    public GameObject audio;
  private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Water")
        {
            audio.SetActive(true);
        }
            
    }
}
