using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class WeaponGenerator : MonoBehaviour
{
    /*
     武器生成器
    三个列表
    武器上已经存在的组件
    所有组件
    组件依赖关系的列表

    开始时清除所有列表
     */

    public Weapon1 weapon;

    private List<WeaponComponent1> componentAlreadyOnWeapon = new List<WeaponComponent1>();

    private List<WeaponComponent1> componentAddedToWeapon = new List<WeaponComponent1>();

    private List<Type> componentDependencies = new List<Type>();

    public WeaponComponentDataSO data;

    private Animator anim;

    private void Start()
    {
        anim = GetComponentInChildren<Animator>();
        GenerateWeapon(data);
    }

    [ContextMenu("test")]
    public void test()
    {
        GenerateWeapon(data);
    }

    public void GenerateWeapon(WeaponComponentDataSO data)
    {
        weapon.setData(data);

        componentAlreadyOnWeapon.Clear();
        componentAddedToWeapon.Clear();
        componentDependencies.Clear();

        componentAlreadyOnWeapon = GetComponents<WeaponComponent1>().ToList();
        //获得所有type
        componentDependencies = data.GetAllDenpendencies();
        //开始遍历添加组件
        foreach(var denpendency in componentDependencies)
        {
            //如果已经存在type相同的组件，跳过
            if (componentAddedToWeapon.FirstOrDefault(component => component.GetType() == denpendency))
                continue;
            var weaponComponent =
                componentAlreadyOnWeapon.FirstOrDefault(component => component.GetType() == denpendency);
            if (weaponComponent == null)
            {
                weaponComponent=gameObject.AddComponent(denpendency) as WeaponComponent1;

            }
            weaponComponent.init();
            componentAddedToWeapon.Add(weaponComponent);
        }
        var componnetsToRemove = componentAlreadyOnWeapon.Except(componentAddedToWeapon);
        
        foreach(var weaponComponent in componnetsToRemove)
        {
            Destroy(weaponComponent);
        }
        anim.runtimeAnimatorController = data.animatorController;


    }
}
