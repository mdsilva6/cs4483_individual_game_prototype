using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Consumable : Item
{
    public int healthAddValue;
    public int staminaAddValue;

    PlayerManager playerManager;
    PlayerStats playerStats;

    void Start()
    {
        playerManager = PlayerManager.instance;
        playerStats = playerManager.player.GetComponent<PlayerStats>();

    }

    public override void Use()
    {
        base.Use();

    }
}
