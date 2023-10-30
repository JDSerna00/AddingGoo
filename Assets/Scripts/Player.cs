using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : Character, IDealDamage, IObserver
{
    float invincibleTime;
    float invincibleAmount = 2.0f;
    private bool isInvicible;

    private GameManager gameManager;
    public static Player Instance { get; private set; }

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

    public Player(int power) : base(3)
    {
        this.power = power;
    }

    public void DealDamage(IDealDamage target)
    {
        if (target is Enemy)
        {            
            (target as Enemy).TakeDamage(1);
            power += (target as Enemy).power;
        }
    }

    public new void TakeDamage(int damage)
    {
        if (damage < 0)
        {
            if (isInvicible)
                return;

            isInvicible = true;
            invincibleTime = invincibleAmount;
        }

        if (lives > 0)
        {
            lives -= damage; 
        }

        if (lives <= 0)
        {
            Destroyed();
            Debug.Log("player is dead");
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
    public override void Destroyed()
    {
        Destroy(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameManager.Instance;
        lives = 1;
        gameManager.SubscribeCollisionObserver(this);
    }

    // Update is called once per frame
    void Update()
    {
        
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
        if (otherCharacter is Enemy)
        {
            int enemyPower = otherCharacter.GetPower();

            if (enemyPower < GetPower())
            {
                PowerUp(enemyPower);
            }
            else 
            {
                TakeDamage(1);
            }
        }
    }
}
