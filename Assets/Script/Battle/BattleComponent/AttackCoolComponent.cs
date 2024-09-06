using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackCoolComponent : BattleComponent
{
    private AttackCoolComponentData data;
    private BattleTrigger trigger;

    protected override void Awake()
    {
        base.Awake();
        
        trigger = GetComponentInParent<BattleTrigger>();
    }
    protected override void OnEnable()
    {
        base.OnEnable();
        trigger.enterPhase += enterPhase1;
    }
    protected override void OnDisable()
    {
        base.OnDisable();
        trigger.enterPhase -= enterPhase1;
    }
    protected override void enterHandler()
    {
        base.enterHandler();
        data = battle.data.getData<AttackCoolComponentData>();
    }

    public void enterPhase1(BattlePhase phase)
    {
        if (phase == BattlePhase.Pre)
        {
            player.startAttackCool1(data.attackCoolTime);
        }
            
    }

}
