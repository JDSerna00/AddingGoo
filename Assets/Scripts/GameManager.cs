using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private bool collisionHandled = false;
    private LevelManager levelManager;
    bool IsGamePaused;
    private float cooldownTimer = 0.0f;
    private float cooldownDuration = 2.0f; // Duración del enfriamiento en segundos

    // Restablece el enfriamiento
    private void ResetCooldown()
    {
        cooldownTimer = 0.0f;
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

    public void HandleCollision(Character character, Character otherCharacter)
    {
        int playerLayer = LayerMask.NameToLayer("CollisionDetection");
        int enemyLayer = LayerMask.NameToLayer("CollisionDetection");

        // Comprueba si ambos personajes están en la capa de detección de colisiones
        if (character.gameObject.layer == playerLayer && otherCharacter.gameObject.layer == enemyLayer)
        {
            if(!IsInCooldown())
            {
                IDealDamage attacker = character as IDealDamage;
                IDealDamage target = otherCharacter as IDealDamage;

                int attackerPower = attacker.GetPower();
                int targetPower = target.GetPower();

                if (attackerPower > targetPower)
                {
                    attacker.DealDamage(target);
                }
                else
                {
                    target.DealDamage(attacker);
                }
                ResetCooldown();
                Debug.Log("Collision detected between: " + character + " and " + otherCharacter); 
            }
        }
    }
    public void PauseGame()
    {
        IsGamePaused = true;
    }

    private bool IsInCooldown()
    {
        return cooldownTimer < cooldownDuration;
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
        cooldownTimer += Time.deltaTime;
    }
}
