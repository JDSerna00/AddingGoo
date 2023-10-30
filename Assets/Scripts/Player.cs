using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : Character, IObserver
{
    public static Player Instance { get; private set; }
    private bool collisionHandled = false;
    private float cooldownTimer = 0.0f;
    private float cooldownDuration = 2.0f;
    private GameManager gameManager;

    private void Awake()
    {
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
    public void OnCollision(Character character, Character otherCharacter)
    {
        if (!IsInCooldown())
        {
            if (otherCharacter is Enemy)
            {
                int enemyPower = otherCharacter.GetPower();

                if (enemyPower < GetPower())
                {
                    // Incrementa el poder del jugador en la cantidad de poder del enemigo.
                    PowerUp(enemyPower);
                }
                else
                {
                    // El jugador recibe daño.
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
        gameManager.UnsubscribeCollisionObserver(this); // Desuscribir al Observer cuando se destruye
    }

    public new void TakeDamage()
    {       
        if (lives > 0)
        {
            lives --;
        }

        if (lives <= 0)
        {
            Destroy(gameObject);
            SceneManager.LoadScene("GameOver");
        }
    }
    public void PowerUp(int powerQuantity)
    {
        power += powerQuantity;
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
        gameManager.SubscribeCollisionObserver(this);
        lives = 3;
        power = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
