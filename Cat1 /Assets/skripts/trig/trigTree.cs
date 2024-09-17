using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trigTree : MonoBehaviour
{

    public Animator animTree;
    public GameObject grond;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            animTree.SetBool("tree", true);
            Destroy(grond);

        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Destroy(gameObject);
        }
    }

}
