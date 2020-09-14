using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class PlayerHealth : MonoBehaviour
{
    public Slider hudLife;
    public int maxHealth = 100;
    public int currentHealth;
    public Sprite deteriorationStage1;
    public Sprite deteriorationStage2;
    public Sprite deteriorationStage3;
    public void Start()
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
    public void Deterioration()
    {
        if (currentHealth <= 60 && currentHealth > 40)
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = deteriorationStage1;
        }

        if (currentHealth <= 20 && currentHealth > 0)
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = deteriorationStage2;
        }
    }
    private void Update()
    {
        Deterioration();
        if (currentHealth <= 0) 
        {
            StartCoroutine(Wait());
        }
    }
    IEnumerator Wait() 
    {
        //SceneManager.LoadScene("Game");
        this.gameObject.GetComponent<SpriteRenderer>().sprite = deteriorationStage3;
        yield return new WaitForSeconds(0.4f);
        currentHealth = 100;
        SetMaxHealth(100);
        SetHealth(100);
        var uiTimer = FindObjectOfType<UiTimer>();
        uiTimer.GameOver();
    }
}
