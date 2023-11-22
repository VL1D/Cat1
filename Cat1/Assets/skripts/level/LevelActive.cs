using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelActive : MonoBehaviour
{
    public GameObject envirActive;
    public GameObject envirActivFalse;
    public GameObject envirActivFals1;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            envirActive.SetActive(true);
            envirActivFals1.SetActive(false);
            envirActivFalse.SetActive(false);
        }
    }

}
