using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static Inventory instance;

    void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one instance of Inventory found");
            return;
        }
        instance = this;
    }
    
    public List<Item> items = new List<Item>();

    public int inventoryCapacity = 30;

    public bool AddToInventory(Item item)
    {
        if (!item.isDefaultItem)
        {
            if (items.Count < inventoryCapacity)
            {
                items.Add(item);
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
    }
}
