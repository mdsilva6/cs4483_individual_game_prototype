using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager instance;

    public bool playerInCombat = false;
    public bool inShelter = false;

    void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Instance of PlayerManager found");
        }
        instance = this;
    }

    public GameObject player;


}
