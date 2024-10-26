using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chicen : MonoBehaviour
{
    public Animator animChick;
    private bool coco = true;
    private void Start()
    {
        animChick = GetComponent<Animator>();
    }

    public void ChicenSit()
    {
        animChick.SetBool("sit", true);
    }
    public void Chicenpect()
    {
        animChick.SetBool("peck", true);
    }

    public void ChicenCoco()
    {
        
        if (coco)
        {
            animChick.SetBool("coco", true);
        }
        else
        {
            animChick.SetBool("coco", false);
        }
    }

    public void ChicennoCoco()
    {
        coco = false;
        StartCoroutine(CiCKCoc());
    }

    private IEnumerator CiCKCoc()
    {
        yield return new WaitForSeconds(5.5f);
        coco = true;
        

    }
}
