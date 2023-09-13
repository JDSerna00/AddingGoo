using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    int actualLevel = 1;
    public List<Enemy> activeEnemies = new List<Enemy>();

    public void LevelStart()
    {
        LoadLevel(actualLevel);
    }


    public void NextLevel()
    {
        actualLevel++; 
        LoadLevel(actualLevel);
    }

    public void LoadLevel(int level)
    {
        SceneManager.LoadScene(level);
    }
    public void RestartLevel()
    {
        LoadLevel(actualLevel);
    }
    public void AddActiveEnemy(Enemy enemy)
    {
        activeEnemies.Add(enemy);
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
    }
    // Start is called before the first frame update
    void Start()
    {
        LoadLevel(actualLevel);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
