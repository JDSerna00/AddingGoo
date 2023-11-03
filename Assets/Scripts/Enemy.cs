using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character, IObserver
{
    private LevelManager levelManager;
    private GameManager gameManager;
    public PowerDisplay powerDisplay;
    private bool hasCollided = false;
    private float cooldownTimer = 0.0f;
    private float cooldownDuration = 2.0f;
    public Enemy(int power) : base(1)
    {
        this.power = power;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!hasCollided)
        {
            Character otherCharacter = collision.gameObject.GetComponent<Character>();

            if (otherCharacter != null)
            {
                foreach (var observer in gameManager.collisionObservers)
                {
                    observer.OnCollision(this, otherCharacter);
                }
                hasCollided = true;
            }
        }
    }
    public void OnCollision(Character character, Character otherCharacter)
    {
        if (character == this && !IsInCooldown())
        {
            if (otherCharacter is Player)
            {
                int playerPower = otherCharacter.GetPower();

                if (playerPower < GetPower())
                {
                    // Incrementa el poder del enemigo en la cantidad de poder del jugador.
                    PowerUp(playerPower);
                }
                else
                {
                    // El enemigo muere.
                    TakeDamage();
                    if (lives <= 0)
                    {
                        Destroy(gameObject);
                    }
                }
                ResetCooldown();
            }
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

    public void PowerUp(int powerQuantity)
    {        
        power += powerQuantity;
        UpdatePowerDisplay();
    }
    private void OnDestroy()
    {
        gameManager.UnsubscribeCollisionObserver(this); // Desuscribir al Observer cuando se destruye
        levelManager.RemoveActiveEnemy(this);
    }
    private void UpdatePowerDisplay()
    {
        powerDisplay.UpdatePower(power);
    }


    // Start is called before the first frame update
    void Start()
    {
        UpdatePowerDisplay();
        lives = 1;
        levelManager = LevelManager.Instance;
        gameManager = GameManager.Instance;
        levelManager.AddActiveEnemy(this);
        gameManager.SubscribeCollisionObserver(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
