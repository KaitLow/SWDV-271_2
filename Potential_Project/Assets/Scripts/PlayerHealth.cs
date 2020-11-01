using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.ThirdPerson;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    // For Variables of Player
    public float fullHealth;
    float currentHealth;
    public bool playerDied = false;

    // For Components of Player
    ThirdPersonUserControl pController;

    // For other Game Objects
    public Canvas playerCanvas;
    public Slider playerHealthSlider;
    void Start()
    {
        Invoke("LoadFirstScene", 1);
    }
    void Awake()
    {
        currentHealth = fullHealth;
        playerHealthSlider.minValue = 0;
        playerHealthSlider.maxValue = fullHealth;
        playerHealthSlider.value = currentHealth;

        pController = GetComponent<ThirdPersonUserControl>();
    }

    void FixedUpdate()
    {
        
    }
    public void AddDamage(float damage)
    {
        currentHealth -= damage;
        playerHealthSlider.value = currentHealth;

        if(currentHealth <= 0)
        {
            playerDied = true;
            playerCanvas.enabled = false;
            pController.enabled = false;
        }
    }
    void LoadFirstScene()
    {
        SceneManager.LoadScene(1);
    }

}
