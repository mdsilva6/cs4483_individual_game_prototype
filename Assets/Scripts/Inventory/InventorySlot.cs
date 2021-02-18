using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    Item item;

    public Image icon;
    public Button removeItemBtn;

    public void StoreItem(Item newItem)
    {
        item = newItem;

        icon.sprite = item.icon;
        icon.enabled = true;
        removeItemBtn.interactable = true;
    }

    public void ClearSlot()
    {
        item = null; 
        icon.sprite = null;
        icon.enabled = false;
        removeItemBtn.interactable = false;
    }

    public void OnRemoveButton()
    {
        Inventory.instance.RemoveFromInventory(item);
    }

    public void UseItem()
    {
        if (item != null)
        {
            item.Use();
        }
    }
}
