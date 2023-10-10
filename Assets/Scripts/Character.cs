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
    public void TakeDamage(int damage)
    {
        lives -= damage;

        if (lives <= 0)
        {
            Destroyed();
        }
    }
    public int GetPower()
    {
        return power;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Character otherCharacter = collision.gameObject.GetComponent<Character>();
        if (otherCharacter != null)
        {
            GameManager.Instance.HandleCollision(this, otherCharacter);
            Debug.Log("Took damage, and has: " + otherCharacter.lives + " lives");
        }
    }
    public abstract void Destroyed();
}
