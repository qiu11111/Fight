using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class WeaponGenerator : MonoBehaviour
{
    /*
     ����������
    �����б�
    �������Ѿ����ڵ����
    �������
    ���������ϵ���б�

    ��ʼʱ��������б�
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
        //�������type
        componentDependencies = data.GetAllDenpendencies();
        //��ʼ����������
        foreach(var denpendency in componentDependencies)
        {
            //����Ѿ�����type��ͬ�����������
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
