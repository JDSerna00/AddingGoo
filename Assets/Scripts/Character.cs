using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour 
{
    LevelManager levelManager;
    public int lives;
    public int power;

    public void TakeDamage(int damage)
    {
        lives -= damage;

        if (lives <= 0)
        {
            Destroyed();
        }
    }
    public abstract void Destroyed();
}
