using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public int actualLevel = 1;

    public List<Enemy> activeEnemies = new List<Enemy>();
    public static LevelManager Instance { get; private set; }

    private void Awake()
    {
        // Asegurarse de que solo haya una instancia
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
            LoadLevel(actualLevel);
            Debug.Log("7");
            // Realizar la inicializaci�n 
        }
        else
        {
            // Si ya hay una instancia, destruir esta.
            Destroy(gameObject);
        }
    }    
    public void LevelStart()
    {
        Time.timeScale = 1;
        LoadLevel(actualLevel);
        Debug.Log("1");
    }


    public void NextLevel()
    {
        Time.timeScale = 1;
        actualLevel++; 
        LoadLevel(actualLevel);
        Debug.Log("2");
    }

    public void GameOver()
    {
        actualLevel = 1;
        SceneManager.LoadScene("GameOver");
    }
    public void LoadLevel(int level)
    {         
        Time.timeScale = 1;
        activeEnemies.Clear();
        SceneManager.LoadScene("Level" + level);
        Debug.Log("3"); 
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

        // Verificar si la lista de enemigos est� vac�a
        if (activeEnemies.Count == 0)
        {
            // Si no hay enemigos activos, avanzar al siguiente nivel
            NextLevel();
            Debug.Log("NextLevel");

        }
        activeEnemies.RemoveAll(item => item == null);
        Debug.Log("6");       
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
