using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentManager : MonoBehaviour
{
    public static EquipmentManager instance;

    public delegate void OnEquipmentChanged(Equipment newEquipment, Equipment oldEquipment);
    public OnEquipmentChanged onEquipmentChangedCallback;

    void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one instance of EquipmentManager found");
        }
        instance = this;

    }

    Equipment[] currentEquipment;

    Inventory inventory;

    void Start()
    {
        inventory = Inventory.instance;
        int numSlots = System.Enum.GetNames(typeof(EquipmentSlot)).Length;
        currentEquipment = new Equipment[numSlots];
    }

    public void Equip(Equipment newEquipment)
    {
        int slotIndex = (int)newEquipment.equipSlot;

        Equipment currentlyEquiped = null;

        if(currentEquipment[slotIndex] != null)
        {
            currentlyEquiped = currentEquipment[slotIndex];
            inventory.AddToInventory(currentlyEquiped);
        }

        if (onEquipmentChangedCallback != null)
        {
            onEquipmentChangedCallback.Invoke(newEquipment, currentlyEquiped);
        }

        currentEquipment[slotIndex] = newEquipment;
    }

    public void Unequip(int slotIndex)
    {
        if (currentEquipment[slotIndex] != null)
        {
            Equipment currentlyEquiped = currentEquipment[slotIndex];
            inventory.AddToInventory(currentlyEquiped);


            if (onEquipmentChangedCallback != null)
            {
                onEquipmentChangedCallback.Invoke(null, currentlyEquiped);
            }

            currentEquipment[slotIndex] = null;

        }
    }

    public void UnequipAll()
    {
        for (int i = 0; i < currentEquipment.Length; i++)
        {
            Unequip(i);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.U))
        {
            UnequipAll();
        }
    }
}
