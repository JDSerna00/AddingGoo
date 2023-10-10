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

    public void HandleCollision(Character character, Character otherCharacter)
    {
        if (character is IDealDamage && otherCharacter is IDealDamage)
        {
            IDealDamage attacker = character as IDealDamage;
            IDealDamage target = otherCharacter as IDealDamage;

            int attackerPower = attacker.GetPower();
            int targetPower = target.GetPower();

            if (attackerPower > targetPower)
            {
                // El personaje con más poder ataca
                attacker.DealDamage(target);
            }
            else
            {
                // El personaje con menos poder recibe daño
                target.DealDamage(attacker);
            }
        }
    }
    public void PauseGame()
    {
        IsGamePaused = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        levelManager = FindObjectOfType<LevelManager>();

        // Llamar al LevelStart una vez
        if (levelManager != null)
        {
            levelManager.LevelStart();
            Debug.Log("8");
        }
        goo.RestartPlayer();
        IsGamePaused = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
