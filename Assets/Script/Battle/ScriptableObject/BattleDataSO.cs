using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


[CreateAssetMenu(fileName ="New Battle",menuName ="BattleDataSO")]
public class BattleDataSO : ScriptableObject
{
    public RuntimeAnimatorController animationComtroller;
    public GameObject SwordSlot;
    [SerializeReference]public List<BattleComponentData> componentData1;
    public Weapons weapon;

    public T getData<T>()
    {
        return componentData1.OfType<T>().FirstOrDefault();
    }

    [ContextMenu("addMove")]
    public void addMove()
    {
        componentData1.Add(new BattleMovementData());
    }

    [ContextMenu("addSword")]
    public void addSword()
    {
        componentData1.Add(new BattleComponentSword());
    }
    [ContextMenu("addBow")]
    public void addBow()
    {
        componentData1.Add(new BattleBowSpriteData());
    }

    [ContextMenu("addHold")]
    public void addHold()
    {
        componentData1.Add(new BattleInputHoldData());
        Debug.Log("Ìí¼Ó³É¹¦");
    }
    [ContextMenu("addPWXBullet")]
    public void addPWXBullet()
    {
        componentData1.Add(new PWXBullet());
    }

    [ContextMenu("addStaff")]
    public void addStaff()
    {
        componentData1.Add(new BattleStaffSpriteData());
    }

    [ContextMenu("addCoolTime")]
    public void addCoolTime()
    {
        componentData1.Add(new AttackCoolComponentData());
    }
    [ContextMenu("addDamage")]
    public void addAttackDamage()
    {
        componentData1.Add(new BattleDamageComponentData());
    }
    public List<Type> getAllDenpendencies()
    {
        return componentData1.Select(component => component.componentDependency).ToList();
    }
}
