using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BosPilar : MonoBehaviour
{
    public Rigidbody2D[] rbStone;
    public GameObject Ef;
    public GameObject Boos;
    public Transform points;
    public bool EndBoos;
    public GameObject Pillar;
    public float speed;

    private void Update()
    {
        if (EndBoos)
        {
            if (Pillar.transform.position.y < points.position.y)
            {
                Pillar.transform.Translate(Vector2.up * speed * Time.deltaTime);
                rbStone[1].isKinematic = true;
            }
        }
    }


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
