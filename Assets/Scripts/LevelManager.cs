using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    int actualLevel = 0;
    public List<Enemy> activeEnemies = new List<Enemy>();

    private static LevelManager instance; 

    public static LevelManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<LevelManager>();

                if (instance == null)
                {
                    GameObject go = new GameObject("LevelManager");
                    instance = go.AddComponent<LevelManager>();
                }
            }

            return instance;
        }
    }
    public void LevelStart()
    {
        LoadLevel(actualLevel);
        Debug.Log("1");
    }


    public void NextLevel()
    {
        actualLevel++; 
        LoadLevel(actualLevel);
        Debug.Log("2");
    }

    public void LoadLevel(int level)
    {
        SceneManager.LoadScene(level);
        activeEnemies.Clear();
        Debug.Log("3");
    }
    public void RestartLevel()
    {
        LoadLevel(actualLevel);
        Debug.Log("4");
    }
    public void AddActiveEnemy(Enemy enemy)
    {
        if (!activeEnemies.Contains(enemy))
        {
            activeEnemies.Add(enemy);
            Debug.Log("5");
        }
        else
        {
            Debug.Log("Enemy already in activeEnemies. Count: " + activeEnemies.Count);
        }
    }

    public void RemoveActiveEnemy(Enemy enemy)
    {
        activeEnemies.Remove(enemy);

        // Verificar si la lista de enemigos está vacía
        if (activeEnemies.Count == 0)
        {
            // Si no hay enemigos activos, avanzar al siguiente nivel
            NextLevel();
        }
        Debug.Log("6");
        activeEnemies.RemoveAll(item => item == null);
    }
    private void Awake()
    {        
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(this.gameObject);

        LoadLevel(actualLevel);
        Debug.Log("7");
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
