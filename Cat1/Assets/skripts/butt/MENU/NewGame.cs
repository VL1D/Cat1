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

    public Animator Panel;
    public GameObject panel;


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
        Panel.SetTrigger("Trig");
        panel.SetActive(true);
        DataCheck.checkPointIndex = 0;
    }

    public void ContineGame()
    {
        Panel.SetTrigger("Trig");
        panel.SetActive(true);
    }

    public void ExitGame()
    {
        Debug.Log("√–¿ «¿ ≤Õ◊»À¿—ﬂ");
        Application.Quit();
    }

    
}
