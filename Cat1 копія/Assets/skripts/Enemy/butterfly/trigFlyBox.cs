using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trigFlyBox : MonoBehaviour
{
    public buterflyidle flyOne;
    public Rigidbody2D box;
    public GameObject coll;

    private void OnTriggerEnter2D(Collider2D collision)
    {
         if(collision.tag == "Fly")
        {
            flyOne.BoxFly = true;
            StartCoroutine(Boxing());
            StartCoroutine(run());
            coll.SetActive(true);
        }
    }

    private IEnumerator run()
    {
        yield return new WaitForSeconds(2.5f);
        flyOne.Fly_run = true;
        flyOne.BoxFly = false;
        yield return new WaitForSeconds(1f);
        Destroy(coll);
        Destroy(gameObject);
    }

    private IEnumerator Boxing()
    {
        yield return new WaitForSeconds(2.45f);
        box.isKinematic = false;

    }
}
