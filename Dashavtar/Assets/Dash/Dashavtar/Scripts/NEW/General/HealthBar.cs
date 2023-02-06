using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HealthBar : MonoBehaviour
{
    public Image fillBar;
    public float currentHealth;
    public float maxHealth;
    private PlayerHealth player;

    private void Start()
    {
        player = FindObjectOfType<PlayerHealth>();
    }

    private void Update()
    {
        currentHealth = player.playerHealth;
        fillBar.fillAmount = currentHealth / maxHealth;
    }
}
