using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum ItemType
{
    Material,Equipment
}

[CreateAssetMenu(fileName ="New Item",menuName ="Material")]
public class ItemData:ScriptableObject
{
    public ItemType itemType;
    public Sprite sprite;
    public string itemName;
}
