using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleMovementComponent : BattleComponent<BattleMovementData,BattleMove>
{
    private BattleTrigger trigger;
    protected override void Awake()
    {
        base.Awake();
        trigger = GetComponentInParent<BattleTrigger>();
    }
    public void handleStartMove()
    {
        player.setMove(currentBattleData.movement);
    }
    public void handleStopMove()
    {
        player.stop();
    }

    protected override void OnEnable()
    {
        base.OnEnable();
        trigger.startMove += handleStartMove;
        trigger.stopMove += handleStopMove;
    }
    protected override void OnDisable()
    {
        base.OnDisable();
        trigger.startMove -= handleStartMove;
        trigger.stopMove -= handleStopMove;
    }
}
