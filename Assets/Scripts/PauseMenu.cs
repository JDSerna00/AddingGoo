using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject PausePanel;

    public void Return()
    {

        PausePanel.SetActive(false);
        Time.timeScale = 1;

    }

    public void MainMenu()
    {

        SceneManager.LoadScene("MainMenu");

    }

    public void Pause()
    {

        PausePanel.SetActive(true);
        Time.timeScale = 0;

    }
}
