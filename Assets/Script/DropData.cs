using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class DropData 
{
    public ItemData itemData;

    [Range(0,100)]
    public float rate;
}
