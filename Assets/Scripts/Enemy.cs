using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : IDealDamage
{
    Vector3 position;
    int lives;
    int power;

    public void Destroyed()
    {

    }

    void IDealDamage.DealDamage()
    {
        throw new NotImplementedException();
    }

    void IDealDamage.TakeDamage()
    {
        throw new NotImplementedException();
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
