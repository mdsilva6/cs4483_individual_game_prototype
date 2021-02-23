using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : CharacterStats
{
    public Text healthPoints;
    public Text staminaPoints;

    public int maxStamina = 100;
    public int currentStamina { get; private set; }

    private void Awake()
    {
        currentStamina = maxStamina;
    }
    void Start()
    {
        EquipmentManager.instance.onEquipmentChangedCallback += OnEquipmentChanged;
        UpdateHud();
        Heal(maxHealth - currentHealth);
    }

    void FixedUpdate()
    {
        UpdateHud();
    }

    void UpdateHud()
    {

        if (currentHealth > 0)
        {
            healthPoints.text = currentHealth.ToString();
            staminaPoints.text = currentStamina.ToString();
        }
        else
        {
            Die();
        }
    }

    void OnEquipmentChanged(Equipment newEquipment, Equipment oldEquipment)
    {
        if (newEquipment != null)
        {
            armour.AddModifier(newEquipment.armorModifier);
            damage.AddModifier(newEquipment.damageModifier);
        }

        if (oldEquipment != null)
        {
            armour.RemoveModifier(oldEquipment.armorModifier);
            damage.RemoveModifier(oldEquipment.damageModifier);
        }
    }

    public override void TakeDamage(int damage)
    {
        base.TakeDamage(damage);

        UpdateHud();

    }

    public void Reengergize(int staminaAmount)
    {
        int temp = currentStamina + staminaAmount;
        if (currentStamina == maxStamina)
        {
            Debug.Log("Already at maxStamina");
        }
        else if (temp > maxStamina)
        {
            currentStamina = maxStamina;
        }
        else
        {
            currentStamina = temp;
        }
    }

    public override void Die()
    {
        // play death animation
        healthPoints.text = "Dead: play death animation";
    }
}
