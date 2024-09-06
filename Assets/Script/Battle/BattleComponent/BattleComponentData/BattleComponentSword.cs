using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class BattleComponentSword : BattleComponentData
{
    public Sprite SwordSprite;

    public BattleComponentSword()
    {
        componentDependency = typeof(SwordSomponent);
    }
}
