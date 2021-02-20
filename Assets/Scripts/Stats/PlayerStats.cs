using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : CharacterStats
{
    public Text healthPoints;


    void Start()
    {
        EquipmentManager.instance.onEquipmentChangedCallback += OnEquipmentChanged;
        healthPoints.text = currentHealth.ToString();
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

        if (currentHealth > 0)
        {
            healthPoints.text = currentHealth.ToString();
        }
        else
        {
            healthPoints.text = "Dead: play death animation";
        }

    }

    public override void Die()
    {
        // play death animation
    }
}
