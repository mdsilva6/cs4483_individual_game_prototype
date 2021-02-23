using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    public int maxHealth = 50;
    public int currentHealth { get; private set; }
    
    public Stat damage;
    public Stat armour;

    public int experienceValue = 50;

    void Awake()
    {
        currentHealth = maxHealth;
    }

    public virtual void TakeDamage (int damage)
    {
        damage = Mathf.Clamp(damage, 0, int.MaxValue);
        currentHealth -= damage;

        //Debug.Log(transform.name + " takes " + damage + " damage");

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public virtual void Heal (int healthPoints)
    {
        int temp = currentHealth + healthPoints;

        if (temp > maxHealth)
        {
            currentHealth = maxHealth;
        } else
        {
            currentHealth = temp;
        }
    }


    public virtual void Die()
    {
        Debug.Log(transform.name + " has died.");
        Destroy(gameObject);
    }
}
