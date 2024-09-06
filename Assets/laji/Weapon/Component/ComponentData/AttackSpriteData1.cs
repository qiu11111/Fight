using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class AttackSpriteData1 : ComponentData1<AttackSprite>
{
    public AttackSpriteData1()
    {
        ComponentDependency = typeof(WeaponSprite1);
    }
}
