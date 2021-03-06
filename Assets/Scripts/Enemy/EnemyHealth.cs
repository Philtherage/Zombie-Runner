﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] float health = 100f;


    bool alreadyDead = false;

    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(float damage)
    {
        BroadcastMessage("OnDamageTaken");
        health -= damage;
        if(health <= 0 && !alreadyDead)
        {
            //Destroy(gameObject, 2f);
            SendMessage("OnDeath");
            animator.SetTrigger("isDead");
            alreadyDead = true;
        }
    }
}
