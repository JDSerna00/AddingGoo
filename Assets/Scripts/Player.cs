using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : Character, IObserver
{
    public static Player Instance { get; private set; }
    public PowerDisplay powerDisplay;
    public LivesDisplay livesDisplay;
    public LevelManager levelManager;
    private bool collisionHandled = false;
    private float cooldownTimer = 0.0f;
    private float cooldownDuration = 2.0f;
    private GameManager gameManager;
    private GameObject live1;
    private GameObject live2;
    private GameObject live3;

    private void Awake()
    {
        live1 = GameObject.Find("Live1");
        live2 = GameObject.Find("Live2");
        live3 = GameObject.Find("Live3");
        // Asegurarse de que solo haya una instancia del jugador.
        if (Instance == null)
        {
            Instance = this;
            // Realizar la inicialización del jugador...
        }
        else
        {
            // Si ya hay una instancia, destruir esta.
            Destroy(gameObject);
        }
    }

    public Player(int power) : base(1)
    {
        this.power = power;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Character otherCharacter = collision.gameObject.GetComponent<Character>();

        if (otherCharacter != null)
        {
            foreach (var observer in gameManager.collisionObservers)
            {
                observer.OnCollision(this, otherCharacter);
            }
        }
    }
    private void UpdatePowerDisplay()
    {
        powerDisplay.UpdatePower(power);
    }
    private void UpdateLivesDisplay()
    {
        livesDisplay.UpdateLives(lives);
    }
    public void OnCollision(Character character, Character otherCharacter)
    {
        if (!IsInCooldown())
        {
            if (otherCharacter is Enemy)
            {
                int enemyPower = otherCharacter.GetPower();

                if (enemyPower < GetPower())
                {
                    PowerUp(enemyPower);
                }
                else
                {
                    TakeDamage();
                }
            }
            ResetCooldown();
        }
    }
    private bool IsInCooldown()
    {
        return cooldownTimer < cooldownDuration;
    }

    private void ResetCooldown()
    {
        cooldownTimer = cooldownDuration;
    }
    private void OnDestroy()
    {
        gameManager.UnsubscribeCollisionObserver(this);
    }

    public new void TakeDamage()
    {       
        if (lives > 0)
        {
            lives --;
            UpdateLivesDisplay();
        }

        if (lives ==2)
        {

            Destroy(live3);
            UpdateLivesDisplay();

        }

        if (lives == 1)
        {

            Destroy(live2);
            UpdateLivesDisplay();

        }

        if (lives <= 0)
        {
            Destroy(gameObject);
            Debug.Log("player is dead");
            levelManager.actualLevel = 1;
            SceneManager.LoadScene("GameOver");
        }
    }
    public void PowerUp(int powerQuantity)
    {
        power += powerQuantity;
        UpdatePowerDisplay();
    }

    public void RestartPlayer()
    {
        lives = 3;
        power = 0;
    }

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameManager.Instance;
        levelManager = LevelManager.Instance;
        gameManager.SubscribeCollisionObserver(this);
        lives = 3;
        power = 0;
        UpdatePowerDisplay();
        UpdateLivesDisplay();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
