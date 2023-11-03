using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private LevelManager levelManager;
    public List<IObserver> collisionObservers = new List<IObserver>();

    public void SubscribeCollisionObserver(IObserver observer)
    {
        collisionObservers.Add(observer);
    }

    public void UnsubscribeCollisionObserver(IObserver observer)
    {
        collisionObservers.Remove(observer);
    }

    //Singleton del gameManager
    public static GameManager Instance { get; private set; }

    private void Awake()
    {
        // Asegurarse de que solo haya una instancia
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            // Realizar la inicialización 
        }
        else
        {
            // Si ya hay una instancia, destruir esta.
            Destroy(gameObject);
        }
    }

    public void EndGame()
    {
        SceneManager.LoadScene("GameOver");
    }


    // Start is called before the first frame update
    void Start()
    {
        levelManager = LevelManager.Instance;
        Player goo = Player.Instance;

        // Llamar al LevelStart una vez
        if (levelManager != null)
        {
            levelManager.LevelStart();
            Debug.Log("8");
        }
        goo.RestartPlayer();
        Debug.Log("Goo has: " + goo.lives + " lives");
        Debug.Log("Goo has: " + goo.power+ " power");
    }

    // Update is called once per frame
    void Update()
    {
    }
}
