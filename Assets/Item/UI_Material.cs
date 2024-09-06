using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_Material : MonoBehaviour,IPointerDownHandler
{
    public Image image;
    public TextMeshProUGUI text;

    public InventoryItem inventoryItem;

    public virtual void OnPointerDown(PointerEventData eventData)
    {
        if (inventoryItem != null)
        {
            if (inventoryItem.itemData.itemType == ItemType.Equipment)
            {
                Inventory.instance.equip((ItemData_Equipment)inventoryItem.itemData);
            }
        }
    }

    public void updateSlot(InventoryItem item)
    {
        inventoryItem = item;
        if (inventoryItem != null)
        {
            image.sprite = inventoryItem.itemData.sprite;
            if (inventoryItem.itemCount > 1)
            {
                text.text = inventoryItem.itemCount.ToString();
            }
            else
            {
                text.text = "";
            }
        }
        image.color = Color.white;
    }

    public void cleanSlot()
    {
        inventoryItem = null;
        image.sprite = null;
        image.color = Color.clear;
    }
}
