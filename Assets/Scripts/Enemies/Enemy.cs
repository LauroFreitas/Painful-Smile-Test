using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public Slider hudLife;
    public int maxHealth = 100;
    public int currentHealth;

    private void Start()
    {
        currentHealth = maxHealth;
        SetMaxHealth(maxHealth);
    }
    public void TakeDamage(int damege) 
    {
        currentHealth -= damege;
        SetHealth(currentHealth);
    }
    public void SetMaxHealth(int health) 
    {
        hudLife.maxValue = health;
        hudLife.value = health;
    }
    public void SetHealth(int health) 
    {
        hudLife.value = health;
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            TakeDamage(20);
        }
    }
}
