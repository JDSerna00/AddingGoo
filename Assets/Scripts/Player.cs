using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : Character, IDealDamage
{
    public static Player Instance { get; private set; }
    private GameManager gameManager;

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
            (target as Enemy).TakeDamage();
            power += (target as Enemy).power;
        }
    }

    public new void TakeDamage()
    {       
        if (lives > 0)
        {
            lives --;
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
        lives = 1;
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
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
