using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ComponentGenerator : MonoBehaviour
{

   /* 武器生成器
   三个列表
    武器上已经存在的组件
    所有组件
    组件依赖关系的列表

    开始时清除所有列表*/



    public Battle weapon;

    private List<BattleComponent> componentAlreadyOnWeapon = new List<BattleComponent>();

    private List<BattleComponent> componentAddedToWeapon = new List<BattleComponent>();

    private List<Type> componentDependencies = new List<Type>();

    public BattleDataSO data;

    private Animator anim;

    public List<BattleDataSO> list;

    public int index;


    private void Start()
    {
        anim = GetComponentInParent<Animator>();
        
        data = list[index];
        GenerateWeapon(data);
    }

    [ContextMenu("test")]
    public void test()
    {
        GenerateWeapon(data);
    }

    public void GenerateWeapon(BattleDataSO data)
    {
        weapon.setData(data);

        componentAlreadyOnWeapon.Clear();
        componentAddedToWeapon.Clear();
        componentDependencies.Clear();

        componentAlreadyOnWeapon = GetComponents<BattleComponent>().ToList();
        //获得所有type
        componentDependencies = data.getAllDenpendencies();
        //开始遍历添加组件
        foreach (var denpendency in componentDependencies)
        {
            //如果已经存在type相同的组件，跳过
            if (componentAddedToWeapon.FirstOrDefault(component => component.GetType() == denpendency))
                continue;
            var weaponComponent =
                componentAlreadyOnWeapon.FirstOrDefault(component => component.GetType() == denpendency);
            if (weaponComponent == null)
            {
                weaponComponent = gameObject.AddComponent(denpendency) as BattleComponent;

            }
            //weaponComponent.init();
            componentAddedToWeapon.Add(weaponComponent);
        }
        var componnetsToRemove = componentAlreadyOnWeapon.Except(componentAddedToWeapon);

        foreach (var weaponComponent in componnetsToRemove)
        {
            Destroy(weaponComponent);
        }
        //anim.runtimeAnimatorController = data.animationComtroller;


    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            index++;
            if (index >= list.Count)
                index = 0;
            data = list[index];
            GenerateWeapon(data);
            PlayerManager.instance.player.isAttackCool = false;
        }
    }
}
