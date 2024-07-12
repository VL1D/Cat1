using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrigDeleteLevel : MonoBehaviour
{
   public void DelLevel()
    {
        Destroy(gameObject);
        LEVBOOL.ent = false;
    }
}
