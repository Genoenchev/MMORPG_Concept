using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    private float MaxHealth = 100f;
    private float HealthContainer;
    [SerializeField] private Health health;
    private float currentHealth;
    [SerializeField] private Image _healthBarFill;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = MaxHealth;
    }

    private void Update()
    {
        health.OnTakeDamage += HandleTakeDamage;
    }

    private void HandleTakeDamage()
    {
        HealthContainer = MaxHealth - health.health;
        currentHealth += HealthContainer;


        float targetFillAmount = health.health / currentHealth;
        _healthBarFill.fillAmount = targetFillAmount;

        currentHealth = health.health;
    }
}
