using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static Inventory instance;

    public GameObject inventoryPanel;

    public bool inventoryOpen = false;

    void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one instance of Inventory found");
            return;
        }
        instance = this;
    }

    void Start()
    {
        inventoryPanel.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            if (!inventoryOpen)
            {
                OpenInventory();
            }
            else
            {
                CloseInventory();
                inventoryOpen = false;
            }
        }
    }

    void OpenInventory()
    {
        inventoryPanel.SetActive(true);
        //Time.timeScale = 0f;
        inventoryOpen = true;
    }

    void CloseInventory()
    {
        inventoryPanel.SetActive(false);
        //Time.timeScale = 1f;
        inventoryOpen = false;
    }

    public delegate void OnInventoryChanged();
    public OnInventoryChanged onInventoryChangedCallback;
    
    public List<Item> items = new List<Item>();

    public int inventoryCapacity = 30;

    public bool AddToInventory(Item item)
    {
        if (!item.isDefaultItem)
        {
            if (items.Count < inventoryCapacity)
            {
                items.Add(item);
                if (onInventoryChangedCallback != null)
                {
                    onInventoryChangedCallback.Invoke();
                }
                return true;
            }
            else
            {
                Debug.Log("Inventory full");
                return false;
            }
        }
        return true;
    }

    public void RemoveFromInventory(Item item)
    {
        items.Remove(item);
        if (onInventoryChangedCallback != null)
        {
            onInventoryChangedCallback.Invoke();
        }
    }
}
