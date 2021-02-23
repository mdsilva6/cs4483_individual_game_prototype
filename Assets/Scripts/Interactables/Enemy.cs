using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterStats))]
public class Enemy : Interactable
{
    PlayerManager playerManager;
    CharacterStats myStats;
    Animator animator;
    PlayerStats playerStats;

    void Start()
    {
        base.Start();
        playerManager = PlayerManager.instance;
        myStats = GetComponent<CharacterStats>();
        animator = playerManager.player.GetComponent<Animator>();
        playerStats = playerManager.player.GetComponent<PlayerStats>();
    }

    void Update()
    {
        base.Update();
        if (myStats.currentHealth <= 0)
        {
            playerStats.AddXP(myStats.experienceValue);
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
