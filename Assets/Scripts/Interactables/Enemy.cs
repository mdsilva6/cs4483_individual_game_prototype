using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterStats))]
public class Enemy : Interactable // followed this tutorial: https://www.youtube.com/watch?v=e8GmfoaOB4Y&ab_channel=Brackeys
{
    PlayerManager playerManager;
    CharacterStats myStats;
    Animator animator;
    PlayerStats playerStats;

    Inventory inventory;

    public Item lootForPlayer;

    void Start()
    {
        base.Start();
        playerManager = PlayerManager.instance;
        myStats = GetComponent<CharacterStats>();
        animator = playerManager.player.GetComponent<Animator>();
        playerStats = playerManager.player.GetComponent<PlayerStats>();
        inventory = playerManager.player.GetComponent<Inventory>();
    }

    void Update()
    {
        base.Update();
        if (myStats.currentHealth <= 0)
        {
            playerStats.AddXP(myStats.experienceValue);
            if (lootForPlayer != null)
            {
                Debug.Log("Player gets " + lootForPlayer.name);
                inventory.AddToInventory(lootForPlayer);
            }
        }
    }
    
    public override void Interact()
    {
        base.Interact();
        CharacterCombat playerCombat = playerManager.player.GetComponent<CharacterCombat>();
        if (playerCombat != null)
        {
            playerCombat.Attack(myStats);
            Debug.Log(myStats.currentHealth.ToString() + " of " + myStats.maxHealth);
        }
    }
}
