using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trigTree : MonoBehaviour
{

    public Animator animTree;
    public GameObject tree;
    public GameObject grond;

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            animTree.SetBool("tree", true);
            Destroy(grond);

        }
    }
    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Destroy(tree);
            Destroy(gameObject);
        }
    }

}
