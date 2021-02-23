using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : Interactable // based off of this tutorial https://www.youtube.com/watch?v=HQNl3Ff2Lpo
{
    public Item item;
    
    // Start is called before the first frame update
    void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    void Update()
    {
        base.Update();
    }

    public override void Interact()
    {
        base.Interact();

        Pickup();
    }

    void Pickup()
    {
        Debug.Log("Picking up " + item.name);
        bool wasPickedUp = Inventory.instance.AddToInventory(item);
        if (wasPickedUp)
        {
            Destroy(gameObject);
        }
    }
}
