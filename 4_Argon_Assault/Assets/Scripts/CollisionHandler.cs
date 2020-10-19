﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [Tooltip("In seconds")][SerializeField] float loadLevelDelay = 1f;
    [Tooltip("FX prefab on player")] [SerializeField] GameObject deathFX;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        StartDeathSequence();
        deathFX.SetActive(true);
        Invoke("ReloadScene", loadLevelDelay); 
    }
    private void ReloadScene()  // String referenced
    {
        SceneManager.LoadScene(1);
    }

    private void StartDeathSequence()
    {
        SendMessage("OnPlayerDeath");
    }

    private void OnCollisionEnter(Collision collision)
    {
        //print("Player hit something");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
