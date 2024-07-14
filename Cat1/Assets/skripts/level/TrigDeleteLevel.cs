using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrigDeleteLevel : MonoBehaviour
{
    private void Start()
    {
        LEVBOOL.ent = false;
    }
   public void DelLevel()
    {
        Destroy(gameObject);
    }
}
