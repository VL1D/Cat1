using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewGame : MonoBehaviour
{
    public int scene;

    public void StartNewGame()
    {
        SceneManager.LoadScene(scene);
        DataCheck.checkPointIndex = 0;
    }

    public void ExitGame()
    {
        Debug.Log("√–¿ «¿ ≤Õ◊»À¿—ﬂ");
        Application.Quit();
    }
}
