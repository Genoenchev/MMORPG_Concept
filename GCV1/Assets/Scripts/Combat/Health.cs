using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int maxHealth = 100;

    public int health;
    public bool IsDead => health == 0;

    public event Action OnTakeDamage;
    public event Action OnDie;


    private void Start()
    {
        health = maxHealth;
    }

    public void DealDamage(int damage)
    {
        if (health == 0) { return; }

        health = Mathf.Max(health - damage, 0);

        OnTakeDamage?.Invoke();

        if (health ==0 )
        {
            OnDie?.Invoke();
        }

        Debug.Log(health);
    }
}
