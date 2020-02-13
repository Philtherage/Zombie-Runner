using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{

    [SerializeField] Slider healthBar;
    [SerializeField] int health = 100;



    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        SetupHealthBar();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateHealthBar();
    }

    public void PlayerTakeDamage(int damage)
    {
        health -= damage;
    }

    public int GetHealth() 
    { 
        return health;
    }

    private void SetupHealthBar()
    {
        healthBar.wholeNumbers = true;
        healthBar.minValue = 0;
        healthBar.maxValue = health;

        healthBar.value = health;
    }

    private void UpdateHealthBar()
    {
        healthBar.value = health;
    }
}
