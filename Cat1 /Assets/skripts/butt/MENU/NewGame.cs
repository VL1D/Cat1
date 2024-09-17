using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NewGame : MonoBehaviour
{
    [Header("Menu Buttons")]

     public Button newGameButton;

     public Button contieneGameButton;


    public int Scene;


    private void Start()
    {
        if (!DataPerfistusManager.instance.HasGameData())
        {
            contieneGameButton.interactable = false;
        }
    }

    public void StartNewGame()
    {
        DataPerfistusManager.instance.NewGame();
        SceneManager.LoadSceneAsync(Scene);
        DataCheck.checkPointIndex = 0;
    }

    public void ContineGame()
    {
        SceneManager.LoadSceneAsync(Scene);
        
    }

    public void ExitGame()
    {
        Debug.Log("√–¿ «¿ ≤Õ◊»À¿—ﬂ");
        Application.Quit();
    }

    
}
