using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        print("Player triggered an event");
        StartDeathSequence();
    }

    private void StartDeathSequence()
    {
        print("Player dying");
        SendMessage("OnPlayerDeath");
    }

    private void OnCollisionEnter(Collision collision)
    {
        print("Player hit something");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
