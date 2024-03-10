using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PointsTrig : MonoBehaviour
{
    public Transform[] posPointsFly;
    public GameObject[] fly;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Fly" )
        {
            StartCoroutine(PosNeckst());
        }

        if (collision.tag == "Fly" && transform.position == posPointsFly[0].position )
        {
            StartCoroutine(PosNecksto());
        }

        if (collision.tag == "Fly" && transform.position == posPointsFly[1].position)
        {
            StartCoroutine(PosNeckstt());
        }
        if (collision.tag == "Fly" && transform.position == posPointsFly[2].position)
        {
            StartCoroutine(PosNeckstf());
        }
    }

    private IEnumerator PosNeckst()
    {
        yield return new WaitForSeconds(0.9f);
        transform.position = posPointsFly[0].position;

    }

    private IEnumerator PosNecksto()
    {
        yield return new WaitForSeconds(0.9f);
        transform.position = posPointsFly[1].position;

    }
    private IEnumerator PosNeckstt()
    {
        yield return new WaitForSeconds(0.9f);
        transform.position = posPointsFly[2].position;

    }

    private IEnumerator PosNeckstf()
    {
        yield return new WaitForSeconds(0.9f);
        transform.position = posPointsFly[3].position;
        fly[0].transform.position = transform.position;
        fly[1].transform.position = transform.position;
    }
}
