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

    public Equipment[] defaultItems;
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

        EquipDefaultItems();
    }

    public void Equip(Equipment newEquipment)
    {
        int slotIndex = (int)newEquipment.equipSlot;
        Equipment currentlyEquiped = Unequip(slotIndex);

        if (onEquipmentChangedCallback != null)
        {
            onEquipmentChangedCallback.Invoke(newEquipment, currentlyEquiped);
        }
        SetEquipmentBlendshapes(newEquipment, 100);

        currentEquipment[slotIndex] = newEquipment;
        SkinnedMeshRenderer newMesh = Instantiate<SkinnedMeshRenderer>(newEquipment.mesh);
        newMesh.transform.parent = targetMesh.transform;

        newMesh.bones = targetMesh.bones;
        newMesh.rootBone = targetMesh.rootBone;
        currentMeshes[slotIndex] = newMesh;
    }

    public Equipment Unequip(int slotIndex)
    {
        if (currentEquipment[slotIndex] != null)
        {
            if (currentMeshes[slotIndex] != null)
            {
                Destroy(currentMeshes[slotIndex].gameObject);
            }
            Equipment currentlyEquiped = currentEquipment[slotIndex];
            SetEquipmentBlendshapes(currentlyEquiped, 0);
            inventory.AddToInventory(currentlyEquiped);


            if (onEquipmentChangedCallback != null)
            {
                onEquipmentChangedCallback.Invoke(null, currentlyEquiped);
            }

            currentEquipment[slotIndex] = null;
            return currentlyEquiped;
        }
        return null;
    }

    public void UnequipAll()
    {
        for (int i = 0; i < currentEquipment.Length; i++)
        {
            Unequip(i);
        }

        EquipDefaultItems();

    }

    void SetEquipmentBlendshapes(Equipment equipment, int weight)
    {
        foreach (EquipmentMeshRegion blendShape in equipment.coveredMeshRegion)
        {
            targetMesh.SetBlendShapeWeight((int)blendShape, weight  );  
        }
    }

    void EquipDefaultItems()
    {
        foreach (Equipment equipment in defaultItems)
        {
            Equip(equipment);
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
