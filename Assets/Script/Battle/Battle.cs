using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battle : MonoBehaviour
{
    public BattleDataSO data;
    public Animator baseAnim;
    public int currentAttackCounter;
    public BattleTrigger battleTrigger;
    public event Action exit;
    public event Action enter;

    public bool currentInput;
    public bool CurrentInput
    {
        get => currentInput;
        set
        {
            if (value != currentInput)
            {
                currentInput = value;
                onCurrentInputChange?.Invoke(currentInput);
            }
        }
    }
    public event Action<bool> onCurrentInputChange;

    public SpriteRenderer baseObject;

    public void setData(BattleDataSO data)
    {
        this.data = data;
    }

    private void Awake()
    {
        baseAnim = GetComponentInParent<Animator>();
        battleTrigger = GetComponentInParent<BattleTrigger>();
        // baseObject = transform.Find("Player1").gameObject.GetComponent<SpriteRenderer>();
        baseObject = GetComponentInParent<Player>().sr;
    }
    public void onEnter()
    {
        if (currentAttackCounter >= 3)
            currentAttackCounter = 0;
        baseAnim.runtimeAnimatorController = data.animationComtroller;
        baseAnim.SetBool("active", true);
        baseAnim.SetInteger("counter", currentAttackCounter);
        enter?.Invoke();
    }
    public void onExit()
    {
        baseAnim.SetBool("active", false);
        currentAttackCounter++;
        exit?.Invoke();

    }

    private void OnEnable()
    {
        battleTrigger.onFinish += onExit;
        baseObject.RegisterSpriteChangeCallback(handler);
        
    }
    private void OnDisable()
    {
        battleTrigger.onFinish -= onExit;
        baseObject.UnregisterSpriteChangeCallback(handler);
    }
    public void handler(SpriteRenderer sr)
    {
        Debug.Log("Sprite±ä»¯");
    }
   
}
