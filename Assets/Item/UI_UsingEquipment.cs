using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UI_UsingEquipment : UI_Material
{
    public EquipmentType equipmentType;

    public override void OnPointerDown(PointerEventData eventData)
    {
        if (inventoryItem != null)
        {
            Inventory.instance.unEquip((ItemData_Equipment)inventoryItem.itemData);
        }
    }
}
