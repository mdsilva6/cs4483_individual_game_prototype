using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Consumable", menuName = "Inventory/Consumable")]
public class Consumable : Item
{
    public int healthAddValue;
    public int staminaAddValue;

    PlayerManager playerManager;
    PlayerStats playerStats;

    void Initalize()
    {
        playerManager = PlayerManager.instance;
        if (playerManager != null)
        {
            playerStats = playerManager.player.GetComponent<PlayerStats>();
        } else
        {
            Debug.LogError("playerManager is null");
        }

    }

    public override void Use()
    {
        base.Use();
        Debug.Log("Test");
        Initalize();
        if (playerManager == null)
        {
            Debug.LogError("playerStats is null");
        }
        else
        {
            playerStats.Heal(healthAddValue);
            playerStats.Reengergize(staminaAddValue);
        }
    }
}
