using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    int actualLevel = 0;
    public List<Enemy> activeEnemies = new List<Enemy>();

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
        Debug.Log("3");
    }
    public void RestartLevel()
    {
        LoadLevel(actualLevel);
        Debug.Log("4");
    }
    public void AddActiveEnemy(Enemy enemy)
    {
        activeEnemies.Add(enemy);
        Debug.Log("5");
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
    }
    // Start is called before the first frame update
    void Awake()
    {
        LoadLevel(actualLevel);
        Debug.Log("7");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
