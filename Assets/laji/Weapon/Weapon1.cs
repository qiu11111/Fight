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
            //监视当前输入，如果当前输入改变，触发事件
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
 1.武器系统的开启与关闭  完成
2.角色动作  完成  有一个bug：连续快速点击攻击键可能会卡在攻击状态无法退出
3.武器sprite组件的实现
 */
