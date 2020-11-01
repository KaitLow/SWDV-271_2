using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    // For Variables
    public float fullHealth;
    public float currentHealth;
    public bool enemyDied = false;
    // For Local Components

    // For Global Components
    public Canvas enemyCanvas;
    public Slider enemyHealthSlider;

    void Awake()
    {
        currentHealth = fullHealth;
        enemyHealthSlider.minValue = 0;
        enemyHealthSlider.maxValue = fullHealth;
        enemyHealthSlider.value = currentHealth;
    }

    void FixedUpdate()
    {
        
    }
    public void AddDamage(float damage)
    {
        currentHealth -= damage;
        enemyHealthSlider.value = currentHealth;

        if(currentHealth <= 0)
        {
            enemyDied = true;
            MakeDied();
        }
    }
    public void MakeDied()
    {
        Destroy(gameObject, 3f);
    }
}
