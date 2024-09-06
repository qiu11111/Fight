using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static Inventory instance;

    public List<InventoryItem> materialList;
    public List<InventoryItem> equipmentList;
    public List<InventoryItem> usingEquipmentList;

    public Dictionary<ItemData, InventoryItem> materialDictionary;
    public Dictionary<ItemData, InventoryItem> equipmentDictionary;
    public Dictionary<ItemData_Equipment, InventoryItem> usingEquipmentDictionary;

    public Transform materialParent;
    public Transform equipmentParent;
    public Transform usingEquipmentParent;
    public Transform statsParent;

    public UI_Material[] materialSlots;
    public UI_Material[] equipmentSlots;
    public UI_UsingEquipment[] usingEquipmentSlots;
    public UI_Stats_Controller[] stats;

    private void Awake()
    {
        if (instance != null)
            Destroy(gameObject);
        instance = this;
    }

    private void Start()
    {
        materialList = new List<InventoryItem>();
        equipmentList = new List<InventoryItem>();
        usingEquipmentList = new List<InventoryItem>();

        materialDictionary = new Dictionary<ItemData, InventoryItem>();
        equipmentDictionary = new Dictionary<ItemData, InventoryItem>();
        usingEquipmentDictionary = new Dictionary<ItemData_Equipment, InventoryItem>();

        materialSlots = materialParent.GetComponentsInChildren<UI_Material>();
        equipmentSlots = equipmentParent.GetComponentsInChildren<UI_Material>();
        usingEquipmentSlots = usingEquipmentParent.GetComponentsInChildren<UI_UsingEquipment>();

        stats = statsParent.GetComponentsInChildren<UI_Stats_Controller>();
    }

    public void updateSlots()
    {
        for(int i = 0; i < stats.Length; i++)
        {
            stats[i].getValue();
        }
        for(int i = 0; i < materialSlots.Length; i++)
        {
            materialSlots[i].cleanSlot();
        }
        for(int i = 0; i < equipmentSlots.Length; i++)
        {
            equipmentSlots[i].cleanSlot();
        }
        for(int i = 0; i < usingEquipmentSlots.Length; i++)
        {
            usingEquipmentSlots[i].cleanSlot();
        }
        for(int i = 0; i < materialList.Count; i++)
        {
            materialSlots[i].updateSlot(materialList[i]);
        }
        for(int i = 0; i < equipmentList.Count; i++)
        {
            equipmentSlots[i].updateSlot(equipmentList[i]);
        }
        for(int i = 0; i < usingEquipmentSlots.Length; i++)
        {
            foreach(KeyValuePair<ItemData_Equipment,InventoryItem> pair in usingEquipmentDictionary)
            {
                if (pair.Key.equipmentType == usingEquipmentSlots[i].equipmentType)
                {
                    usingEquipmentSlots[i].updateSlot(pair.Value);
                }
            }
        }
    }


    public void equip(ItemData_Equipment itemData)
    {
        ItemData_Equipment itemToRemove = null;
        InventoryItem item = new InventoryItem(itemData);
        //通过类型寻找
        foreach(KeyValuePair<ItemData_Equipment,InventoryItem> pair in usingEquipmentDictionary)
        {
            if (pair.Key.equipmentType == itemData.equipmentType)
            {
                itemToRemove = pair.Key;
            }
        }
        if (itemToRemove != null)
        {
            if(usingEquipmentDictionary.TryGetValue(itemToRemove,out InventoryItem value))
            {
                usingEquipmentList.Remove(value);
                usingEquipmentDictionary.Remove(itemToRemove);
                itemToRemove.remove();
            }
            addItem(itemToRemove);
        }
        usingEquipmentList.Add(item);
        usingEquipmentDictionary.Add(itemData, item);
        itemData.add();
        removeItem(itemData);
        updateSlots();
    }

    public void unEquip(ItemData_Equipment itemData)
    {
        if(usingEquipmentDictionary.TryGetValue(itemData,out InventoryItem value))
        {
            usingEquipmentList.Remove(value);
            usingEquipmentDictionary.Remove(itemData);
            itemData.remove();
            addItem(itemData);
        }
        updateSlots();
    }

    public void addItem(ItemData itemData)
    {
        if (itemData.itemType == ItemType.Material)
        {
            if(materialDictionary.TryGetValue(itemData,out InventoryItem value))
            {
                value.addItem();
            }
            else
            {
                InventoryItem inventoryItem = new InventoryItem(itemData);
                materialList.Add(inventoryItem);
                materialDictionary.Add(itemData, inventoryItem);
            }
        }
        if (itemData.itemType == ItemType.Equipment)
        {
            if(equipmentDictionary.TryGetValue(itemData,out InventoryItem value))
            {
                value.addItem();
            }
            else
            {
                InventoryItem inventoryItem = new InventoryItem(itemData);
                equipmentList.Add(inventoryItem);
                equipmentDictionary.Add(itemData, inventoryItem);
            }
        }
        updateSlots();
    }

    public void removeItem(ItemData itemData)
    {
        if (itemData.itemType == ItemType.Material)
        {
            if(materialDictionary.TryGetValue(itemData,out InventoryItem value))
            {
                if (value.itemCount > 1)
                {
                    value.removeItem();
                }
                else
                {
                    materialList.Remove(value);
                    materialDictionary.Remove(itemData);
                }
            }
        }
        if (itemData.itemType == ItemType.Equipment)
        {
            if(equipmentDictionary.TryGetValue(itemData,out InventoryItem value))
            {
                if (value.itemCount > 1)
                {
                    value.removeItem();
                }
                else
                {
                    equipmentList.Remove(value);
                    equipmentDictionary.Remove(itemData);
                }
            }
        }
        updateSlots();
    }
}
