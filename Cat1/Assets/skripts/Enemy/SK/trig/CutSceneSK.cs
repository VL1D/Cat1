using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutSceneSK : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.tag == "Player")
        {
            CutsceneManager.Instance.StartCutscene("SK");
        }
    }
}
