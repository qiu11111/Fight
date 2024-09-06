using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class BattleDamageComponentData : BattleComponentData<BattleDamageData>
{
    public LayerMask whatIsEnemy;
   public BattleDamageComponentData()
    {
        componentDependency = typeof(BattleDamageComponent);
    }
}
