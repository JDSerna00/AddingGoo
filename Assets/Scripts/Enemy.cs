using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character, IDealDamage
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
        Debug.Log("enemy has: " + lives);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
