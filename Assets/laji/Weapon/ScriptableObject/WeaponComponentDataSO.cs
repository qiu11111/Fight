using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


[CreateAssetMenu(fileName = "New SO", menuName = "SO")]
public class WeaponComponentDataSO : ScriptableObject
{
    public int attackNumber;
    [SerializeReference] public List<ComponentData1> componentDatas;
    public RuntimeAnimatorController animatorController;

    public T getData<T>()
    {
        return componentDatas.OfType<T>().FirstOrDefault();
    }


    [ContextMenu("addSprite")]
    public void addSprite()
    {
        componentDatas.Add(new AttackSpriteData1());
    }
    [ContextMenu("addMovement")]
    public void addMovement()
    {
        componentDatas.Add(new MovementData());
    }
    [ContextMenu("addFrame")]
    public void addFrame()
    {
        componentDatas.Add(new AttackFrameData());
    }
    [ContextMenu("addInput")]
    public void addInput()
    {
        componentDatas.Add(new InputHoldData());
        Debug.Log("Ìí¼Ó³É¹¦");
    }

    public List<Type> GetAllDenpendencies()
    {
        return componentDatas.Select(component => component.ComponentDependency).ToList();
    }

}
