using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character, IDealDamage
{
    private LevelManager levelManager;
    private new int lives = 1;
    public Enemy(int power)
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
       levelManager.RemoveActiveEnemy(this);      
    }

    // Start is called before the first frame update
    void Start()
    {
        levelManager.AddActiveEnemy(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
