using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleMovementData : BattleComponentData<BattleMove>
{
    public BattleMovementData()
    {
        componentDependency = typeof(BattleMovementComponent);
    }
}
