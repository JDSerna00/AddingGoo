using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character, IDealDamage
{
    float invincibleTime;
    float invincibleAmount = 2.0f;
    private bool isInvicible;
    private new int lives = 3;

    public void Movement()
    {

    }

    public void PowerUp(int powerQuantity)
    {
        power += powerQuantity;
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
        }
    }

    public void RestartPlayer()
    {
        lives = 3;
        power = 0;
    }
    public override void Destroyed()
    {
        Destroy(this);
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
