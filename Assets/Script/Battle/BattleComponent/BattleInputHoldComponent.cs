using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleInputHoldComponent : BattleComponent
{
    private Animator anim;

    protected override void Awake()
    {
        base.Awake();
        anim = GetComponentInParent<Animator>();
    }
    private void Update()
    {
        print(anim.GetBool("hold"));
    }
    public void inputChangeHandler(bool input)
    {
        anim.SetBool("hold", input);
    }

    protected override void OnEnable()
    {
        base.OnEnable();
        battle.onCurrentInputChange += inputChangeHandler;

    }
    protected override void OnDisable()
    {
        base.OnDisable();
        battle.onCurrentInputChange -= inputChangeHandler;
    }
}
