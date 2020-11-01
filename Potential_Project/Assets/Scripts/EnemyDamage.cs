using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{

    //For Variables
    public float enemyDamageAmount;
    public DateTime nextDamage;
    public float damageAfterTime;
    public bool enemyInFightingRange = false;
    //For Local Components

    //For Global Component and Game Objects
    public GameObject enemyObj;

    void Awake()
    {
        nextDamage = DateTime.Now;
    }

    void FixedUpdate()
    {
        if(enemyInFightingRange == true)
        {
            DamageEnemy();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Enemy")
        {
            enemyObj = other.gameObject;
            enemyInFightingRange = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Enemy")
        {
            enemyInFightingRange = false;
        }
    }
    public void DamageEnemy()
    {
        if(nextDamage <= DateTime.Now)
        {
            //if(enemyObj.GetComponent<EnemyHealth>().enemyDied == false)
            //{
            //    enemyObj.GetComponent<EnemyHealth>().AddDamage(enemyDamageAmount);
            //}
            nextDamage = DateTime.Now.AddSeconds(System.Convert.ToDouble(damageAfterTime));
        }
    }
}
