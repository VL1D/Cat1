using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trigEndCatScebe : MonoBehaviour
{
   private void OnTriggerEnter2D (Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            CutsceneManager.Instance.StartCutscene("End");
        }
    }
}
