using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHold : WeaponComponent1
{
    private Animator anim;
    private bool input;

    protected override void Awake()
    {
        base.Awake();
        anim = GetComponentInChildren<Animator>();
        weapon.OnCurrentInputChange += handlCurrentInputChange;
    }
    private void setAnimatorParameter()
    {
        anim.SetBool("hold", input);
    }
    private void handlCurrentInputChange(bool newInput)
    {
        input = newInput;
        setAnimatorParameter();
    }
    protected override void OnDisable()
    {
        base.OnDisable();
        weapon.OnCurrentInputChange -= handlCurrentInputChange;
    }
}
