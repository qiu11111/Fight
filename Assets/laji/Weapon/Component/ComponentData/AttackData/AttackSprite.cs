using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class AttackSprite : AttackData
{
    //���빥���׶�Ҫ�����������ݵĶ���
    public PhaseSprites[] phaseSprites;
}

[Serializable]
public struct PhaseSprites
{
    public AttackPhases Phase;
    public Sprite[] sprites;
}