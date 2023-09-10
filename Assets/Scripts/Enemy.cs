using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character, IDealDamage
{
    Vector3 position;
    private new int lives = 1;
    public Enemy(Vector3 position, int power)
    {
        this.position = position;
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
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
