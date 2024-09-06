using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[Serializable]
public class InventoryItem
{
    public ItemData itemData;
    public int itemCount;

    public InventoryItem(ItemData itemData)
    {
        this.itemData = itemData;
        addItem();
    }
    public void addItem()
    {
        itemCount++;
    }
    public void removeItem()
    {
        itemCount--;
    }
        
}
