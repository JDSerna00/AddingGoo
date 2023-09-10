using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour 
{
    Vector3 position;
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
    public void Destroyed()
    {

    }
}
