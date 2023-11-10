using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public GameObject panel;
    public GameObject ButtonPaus;
    public GameObject peredw;

    public void PauseGame()
    {
        panel.SetActive(true);
        Time.timeScale = 0f;
        ButtonPaus.SetActive(false);
        peredw.SetActive(false);

    }

    public void ContionGame()
    {
        panel.SetActive(false);
        Time.timeScale = 1f;
        ButtonPaus.SetActive(true);
        peredw.SetActive(true);

    }
}
