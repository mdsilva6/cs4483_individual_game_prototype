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

    public SkinnedMeshRenderer targetMesh;
    Equipment[] currentEquipment;
    SkinnedMeshRenderer[] currentMeshes;

    Inventory inventory;

    void Start()
    {
        inventory = Inventory.instance;
        int numSlots = System.Enum.GetNames(typeof(EquipmentSlot)).Length;
        currentEquipment = new Equipment[numSlots];
        currentMeshes = new SkinnedMeshRenderer[numSlots];
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
        SkinnedMeshRenderer newMesh = Instantiate<SkinnedMeshRenderer>(newEquipment.mesh);
        newMesh.transform.parent = targetMesh.transform;

        newMesh.bones = targetMesh.bones;
        newMesh.rootBone = targetMesh.rootBone;
        currentMeshes[slotIndex] = newMesh;
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
