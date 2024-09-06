using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon1 : MonoBehaviour
{
    private Animator anim;
    private GameObject BaseObject;
    private GameObject WeaponObject;
    public AnimationTrigger animationTrigger;
    public event Action exit;
    public event Action enter;
    public int currentAttackCounter;
    public WeaponComponentDataSO weaponComponentDataSO;
    public event Action<bool> OnCurrentInputChange;
    public bool CurrentInput
    {
        get => currentInput;
        set
        {
            //���ӵ�ǰ���룬�����ǰ����ı䣬�����¼�
            if (currentInput != value)
            {
                currentInput = value;
                OnCurrentInputChange?.Invoke(currentInput);
            }
        }
    }

    private bool currentInput;
    
    private void Awake()
    {
        BaseObject = transform.Find("BaseObject").gameObject;
        WeaponObject = transform.Find("WeaponObject").gameObject;
        animationTrigger = BaseObject.GetComponent<AnimationTrigger>();
        anim = BaseObject.GetComponent<Animator>();
    }


    public void onEnter()
    {
        if (currentAttackCounter >= weaponComponentDataSO.attackNumber)
            currentAttackCounter = 0;
        anim.SetBool("active", true);
        anim.SetInteger("counter", currentAttackCounter);
        enter?.Invoke();
    }

    public void onExit()
    {
        currentAttackCounter++;
        anim.SetBool("active", false);
        exit?.Invoke();
    }

    private void OnEnable()
    {
        animationTrigger.onFinish += onExit;
    }
    private void OnDisable()
    {
        animationTrigger.onFinish -= onExit;
    }
    public void setData(WeaponComponentDataSO data)
    {
        weaponComponentDataSO = data;
    }
}
/*
 1.����ϵͳ�Ŀ�����ر�  ���
2.��ɫ����  ���  ��һ��bug���������ٵ�����������ܻῨ�ڹ���״̬�޷��˳�
3.����sprite�����ʵ��
 */
