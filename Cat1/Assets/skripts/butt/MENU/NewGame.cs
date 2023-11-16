using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NewGame : MonoBehaviour
{
    [Header("Menu Buttons")]

    [SerializeField] private Button newGameButton;

    [SerializeField] private Button contieneGameButton;

    public int scene;

    private void Start()
    {
        if (!DataPerfistusManager.instance.HasGameData())
        {
            contieneGameButton.interactable = false;
        }
    }

    public void StartNewGame()
    {
        DiableMenuButtons();
        DataPerfistusManager.instance.NewGame();
        SceneManager.LoadSceneAsync(scene);
        DataCheck.checkPointIndex = 0;
    }

    public void ContineGame()
    {
        DiableMenuButtons();
        SceneManager.LoadSceneAsync(scene);
    }

    public void ExitGame()
    {
        Debug.Log("√–¿ «¿ ≤Õ◊»À¿—ﬂ");
        Application.Quit();
    }

    private void DiableMenuButtons()
    {
        newGameButton.interactable = false;
        contieneGameButton.interactable = false;
    }
}
