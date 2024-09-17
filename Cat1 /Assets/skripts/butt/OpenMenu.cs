using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenMenu : MonoBehaviour
{
    public int scene;

    public void Menu()
    {
        SceneManager.LoadScene(scene);
        Time.timeScale = 1f;
    }
}
