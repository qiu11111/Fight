using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] public int numberOfAttack;
    public WeaponDataSO data;
    public int CurrentAttackCounter
    {
        get => currentAttackCounter;
        private set
        {
            if (value > numberOfAttack)
            {
                currentAttackCounter = 0;
            }
            else
            {
                currentAttackCounter = value;
            }
        }
    }
    private int currentAttackCounter;
    


    private Animator anim;
    public GameObject baseObject;
    public GameObject weaponObject;

    private AnimationEventHandler animationEventHandler;
    public event Action onExit;
    public event Action onEnter;

    public void enter()
    {
        anim.SetBool("active", true);
        anim.SetInteger("counter", currentAttackCounter);
        onEnter?.Invoke();

    }
    public void exit()
    {

        anim.SetBool("active", false);
        CurrentAttackCounter++;
        onExit?.Invoke();
    }

    private void Awake()
    {
        baseObject = transform.Find("BaseObject").gameObject;
        weaponObject = transform.Find("WeaponObject").gameObject;
        anim = baseObject.GetComponent<Animator>();
        animationEventHandler = baseObject.GetComponent<AnimationEventHandler>();
    }

    private void OnEnable()
    {
        animationEventHandler.onFinish += exit;
    }
    private void OnDisable()
    {
        animationEventHandler.onFinish -= exit;
    }

}
