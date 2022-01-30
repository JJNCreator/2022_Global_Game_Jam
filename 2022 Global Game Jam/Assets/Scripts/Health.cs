using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int maxHealth = 5;
    public int currentHealth;

    public healthBar healthBar;
    public bool Dead;

    private static Health instance;
    public static Health Instance
    {
        get
        {
            if (instance == null)
                instance = FindObjectOfType<Health>();
            return instance;
        }
    }

    private void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        Dead = false;
    }

    // Update is called once per frame
    void Update()
    {
        // if (something)
        // { TakeDamage(1); }

        if(currentHealth < 1)
        {
            Dead = true;
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }
}
