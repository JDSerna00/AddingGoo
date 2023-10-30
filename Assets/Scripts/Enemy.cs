using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character, IDealDamage, IObserver
{
    private LevelManager levelManager;
    private GameManager gameManager;

    private bool isAdded = false;
    public Enemy(int power) : base(1)
    {
        this.power = power;
    }

    public void DealDamage(IDealDamage target)
    {
        if (target is Player)
        {           
            (target as Player).TakeDamage(1);           
            power += (target as Player).power;
        }
    }
    public override void Destroyed()
    {
        if (lives <= 0)
        {
            levelManager.RemoveActiveEnemy(this);
            Destroy(gameObject);
        }
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

    public void PowerUp(int powerQuantity)
    {
        power += powerQuantity;
    }


    // Start is called before the first frame update
    void Start()
    {
        lives = 1;
        levelManager = LevelManager.Instance;
        gameManager = GameManager.Instance;
        levelManager.AddActiveEnemy(this);
        gameManager.SubscribeCollisionObserver(this);
        Debug.Log("enemy has: " + lives);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnCollision(Character character, Character otherCharacter)
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
                TakeDamage(1);
            }
        }
    }
}
