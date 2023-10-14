using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
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

            Debug.Log("Collision detected between: " + character + " and" + otherCharacter);

        }
    }
    public void PauseGame()
    {
        IsGamePaused = true;
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
        IsGamePaused = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
