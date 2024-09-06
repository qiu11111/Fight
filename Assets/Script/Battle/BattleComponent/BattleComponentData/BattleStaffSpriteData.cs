using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class BattleStaffSpriteData : BattleComponentData
{
    public Sprite sprite;
    public GameObject bullet;
    public BattleStaffSpriteData()
    {
        componentDependency = typeof(BattleStaffComponent);
    }
}
