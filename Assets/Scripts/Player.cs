using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character, IDealDamage
{
    float invincibleTime;
    float invincibleAmount = 2.0f;
    private bool isInvicible;

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
