using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CanwasSccene : MonoBehaviour
{
    public int Scene;

    public void ENDGame()
    {
        SceneManager.LoadSceneAsync(Scene);
        Sound.instance.Ac();
    }
}
