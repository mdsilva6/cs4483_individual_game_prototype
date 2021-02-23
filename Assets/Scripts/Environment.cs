using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Environment : MonoBehaviour
{

    PlayerManager playerManager;
    PlayerStats playerStats;


    private void Start()
    {
        playerManager = PlayerManager.instance;
        playerStats = playerManager.player.GetComponent<PlayerStats>();
        InvokeRepeating("ColdDamage", 2.0f, 2.0f);
    }

    void ColdDamage()
    {
        if (!playerManager.inShelter)
        {
            playerStats.TakeDamage(1);
        } else
        {
            Debug.Log("Player is in shelter and safe from the elements");
        }
    }
}
