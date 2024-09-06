using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleInputHoldData : BattleComponentData
{
    public BattleInputHoldData()
    {
        componentDependency = typeof(BattleInputHoldComponent);
    }
}
