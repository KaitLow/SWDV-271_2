using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] GameObject deathFX; // deaths effect for enemy 
    [SerializeField] Transform parent;  // placeholder to destroy deathFX when done
    [SerializeField] int goldIncrease = 10;
    ScoreBoard goldBoard;
    // For Variables
    public float fullHealth;
    public float currentHealth;
    public bool enemyDied = false;
    // For Local Components

    // For Global Components
    public Canvas enemyCanvas;
    public Slider enemyHealthSlider;
    void Start()
    {
        goldBoard = FindObjectOfType<ScoreBoard>();
    }

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
        GameObject fx = Instantiate(deathFX, transform.position, Quaternion.identity);
        fx.transform.parent = parent;
        goldBoard.ScoreHit(goldIncrease);

        Destroy(gameObject);
    }
}
