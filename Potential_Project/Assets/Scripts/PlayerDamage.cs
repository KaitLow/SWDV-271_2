using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;  // to get time
public class PlayerDamage : MonoBehaviour
{
    // For Variables
    public float playerDamageAmount;
    public bool playerInRange = false;
    public DateTime nextDamage;
    public float damageAfterTime;

    // For Local Component

    // For Global Component and Game Object
    public GameObject playerObj;

    void Awake()
    {
        nextDamage = DateTime.Now;
    }

    void FixedUpdate()
    {
        // check if player in range to damage player
        if (playerInRange == true)
        {
            DamagePlayer();
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if(other.gameObject.GetComponent<PlayerHealth>().playerDied == false)
            {
                playerObj = other.gameObject;
                playerInRange = true;
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            playerInRange = false;
        }
    }
    public void DamagePlayer()
    {
        if(nextDamage <= DateTime.Now)
        {
            playerObj.GetComponent<PlayerHealth>().AddDamage(playerDamageAmount);
            nextDamage = DateTime.Now.AddSeconds(System.Convert.ToDouble(damageAfterTime));
        }
    }
}
