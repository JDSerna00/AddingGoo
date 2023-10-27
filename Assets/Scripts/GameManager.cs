using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private LevelManager levelManager;
    bool IsGamePaused;

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
                attacker.PowerUp(targetPower);
            }
            else
            {
                // El personaje con menos poder recibe daño
                target.DealDamage(attacker);
                target.PowerUp(attackerPower);
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
