using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PanelOne : MonoBehaviour
{
    public void Loading()
    {
        DataPerfistusManager.instance.LoadGame();
        Debug.Log("Loading");
    }

    public void RestrtPanel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

   
}
