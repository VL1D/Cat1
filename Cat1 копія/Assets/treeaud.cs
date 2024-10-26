using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class treeaud : MonoBehaviour
{
    public GameObject audio;
    public float sped;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" || collision.tag == "Tree")
        {
            //audio.SetActive(true);
            StartCoroutine(audi());
        }
    }

    private IEnumerator audi()
    {
        yield return new WaitForSeconds(sped);
        audio.SetActive(true);
    }
}
