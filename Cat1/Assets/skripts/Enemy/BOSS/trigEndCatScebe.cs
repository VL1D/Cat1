using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trigEndCatScebe : MonoBehaviour
{
    public PlayerController Cat;
   private void OnTriggerEnter2D (Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Cat.speed = 0f;
            CutsceneManager.Instance.StartCutscene("End");
        }
    }
}
