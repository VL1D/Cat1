using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RespanDeatch : MonoBehaviour
{
    public Animator panelanim;

   public void Restart()
    {
        panelanim.SetTrigger("triger");
        if(DataCheck.checkPointIndex >= 6)
        {
            LevelManager.instance.RespawnLevel2();
        }
       
    }

}
