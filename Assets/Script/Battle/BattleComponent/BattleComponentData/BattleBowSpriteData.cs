using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleBowSpriteData : BattleComponentData<BowSpriteData>
{
    public BattleBowSpriteData()
    {
        componentDependency = typeof(BattleBowSpriteComponent);
    }   
}
