using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int maxHealth = 5;
    public int currentHealth;

    public healthBar healthBar;
    public bool Dead;

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

    void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }
}
