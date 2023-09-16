using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public void Return()
    {

        SceneManager.LoadScene("GameScene");

    }

    public void MainMenu()
    {

        SceneManager.LoadScene("MainMenu");

    }
}
