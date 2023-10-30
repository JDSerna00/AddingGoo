using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour 
{
    public int lives;
    public int power;

    public Character(int initialLives)
    {
        lives = initialLives;
    }
    public void TakeDamage()
    {
        lives--;
    }
    public int GetPower()
    {
        return power;
    }
}
