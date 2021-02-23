using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour // followed this tutorial: https://www.youtube.com/watch?v=YLhj7SfaxSE&ab_channel=Brackeys
{

    public Transform itemsParent;
    
    Inventory inventory;

    InventorySlot[] inventorySlotArray;

    // Start is called before the first frame update
    void Start()
    {
        inventory = Inventory.instance;
        inventory.onInventoryChangedCallback += UpdateUI;
        inventorySlotArray = itemsParent.GetComponentsInChildren<InventorySlot>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void UpdateUI()
    {
        Debug.Log("Updating UI");
        for (int i = 0; i < inventorySlotArray.Length; i++)
        {
            if (i < inventory.items.Count)
            {
                inventorySlotArray[i].StoreItem(inventory.items[i]);
            }
            else
            {
                inventorySlotArray[i].ClearSlot();
            }
        }
    }
}
