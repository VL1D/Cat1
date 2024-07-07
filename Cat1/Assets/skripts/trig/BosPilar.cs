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
    public GameObject[] audio;
    public float soAud;
    public float soAude;

    private void Update()
    {
        if (EndBoos)
        {
            if (Pillar.transform.position.y < points.position.y)
            {
                Pillar.transform.Translate(Vector2.up * speed * Time.deltaTime);
                rbStone[1].isKinematic = true;
                audio[1].SetActive(true);
                StartCoroutine(Actex());
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
            StartCoroutine(ActAu());
        }
    }

    private IEnumerator ActBoos()
    {
        yield return new WaitForSeconds(8f);
        Boos.SetActive(true);

    }
    private IEnumerator ActAu()
    {
        yield return new WaitForSeconds(soAud);
        audio[0].SetActive(true);

    }
    private IEnumerator Actex()
    {
        yield return new WaitForSeconds(soAude);
        audio[1].SetActive(false);

    }
}
