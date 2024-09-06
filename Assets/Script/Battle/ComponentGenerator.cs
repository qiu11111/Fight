using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ComponentGenerator : MonoBehaviour
{

   /* ����������
   �����б�
    �������Ѿ����ڵ����
    �������
    ���������ϵ���б�

    ��ʼʱ��������б�*/



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
        //�������type
        componentDependencies = data.getAllDenpendencies();
        //��ʼ����������
        foreach (var denpendency in componentDependencies)
        {
            //����Ѿ�����type��ͬ�����������
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
