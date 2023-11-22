using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Panel : MonoBehaviour
{
    public int Scene;

    public void PanelAnim()
    {
        SceneManager.LoadSceneAsync(Scene);
    }


}
