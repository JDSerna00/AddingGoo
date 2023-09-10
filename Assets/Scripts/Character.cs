using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : IDealDamage
{
    Vector3 position;
    int lives;
    int power;
    float invincibleTime;
    bool isinvicible;

    public void Movement()
    {

    }

    public void PowerUp()
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
