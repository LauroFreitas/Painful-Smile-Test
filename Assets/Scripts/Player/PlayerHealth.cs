using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public Slider hudLife;
    public int maxHealth = 100;
    public int currentHealth;
    virtual public void Start()
    {
        currentHealth = maxHealth;
        SetMaxHealth(maxHealth);
    }
    virtual public void TakeDamage(int damege)
    {
        currentHealth -= damege;
        SetHealth(currentHealth);
    }
    virtual public void SetMaxHealth(int health)
    {
        hudLife.maxValue = health;
        hudLife.value = health;
    }
    virtual public void SetHealth(int health)
    {
        hudLife.value = health;
    }
}
