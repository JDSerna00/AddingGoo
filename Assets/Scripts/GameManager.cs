using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Player goo;
    private LevelManager levelManager;
    bool IsGamePaused;

    //Singleton del gameManager
    private static GameManager instance;
    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<GameManager>();
                if (instance == null)
                {
                    GameObject go = new GameObject("GameManager");
                    instance = go.AddComponent<GameManager>();
                }
            }
            return instance;
        }
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void EndGame()
    {
        SceneManager.LoadScene("GameOver");
    }
    public void PauseGame()
    {

        IsGamePaused = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        goo.RestartPlayer();
        levelManager.LevelStart();
        IsGamePaused = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
