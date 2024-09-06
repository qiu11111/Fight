using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class AttackCoolComponentData : BattleComponentData
{
    public float attackCoolTime;
    public AttackCoolComponentData()
    {
        componentDependency = typeof(AttackCoolComponent);
    }
}
