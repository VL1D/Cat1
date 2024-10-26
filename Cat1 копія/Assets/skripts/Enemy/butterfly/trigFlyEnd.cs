using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trigFlyEnd : MonoBehaviour
{
    public buterflyidle flyOne;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Fly")
        {
            flyOne.BoxFly = true;
        }

        if (collision.tag == "Player")
        {
            flyOne.BoxFly = true;
            CutsceneManager.Instance.StartCutscene("CatSceneFlyEnd");
        }
    }
}
