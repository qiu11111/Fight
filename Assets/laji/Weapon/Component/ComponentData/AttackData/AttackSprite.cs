using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class AttackSprite : AttackData
{
    //引入攻击阶段要更新武器数据的定义
    public PhaseSprites[] phaseSprites;
}

[Serializable]
public struct PhaseSprites
{
    public AttackPhases Phase;
    public Sprite[] sprites;
}