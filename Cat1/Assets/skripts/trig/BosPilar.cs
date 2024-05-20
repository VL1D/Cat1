using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BosPilar : MonoBehaviour
{
    public Rigidbody2D[] rbStone;
    public GameObject Ef;
    public GameObject Boos;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            rbStone[0].isKinematic = false;
            rbStone[1].isKinematic = false;
            Ef.SetActive(true);
            StartCoroutine(ActBoos());
        }
    }

    private IEnumerator ActBoos()
    {
        yield return new WaitForSeconds(8f);
        Boos.SetActive(true);

    }
}
