using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trigDestroFstone : MonoBehaviour
{
    private IEnumerator StoneDestr()
    {
        yield return new WaitForSeconds(10f);
        Destroy(gameObject);

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            StartCoroutine(StoneDestr());
        }
    }
}
