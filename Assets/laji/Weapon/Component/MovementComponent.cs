using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementComponent : WeaponComponent1<MovementData,AttackMovement>
{

    private AnimationTrigger trigger;

    protected override void Awake()
    {
        base.Awake();
        trigger = transform.Find("BaseObject").GetComponent<AnimationTrigger>();
    }
    protected override void OnEnable()
    {
        base.OnEnable();
        /*        weapon.animationTrigger.onMove += startMove;
                weapon.animationTrigger.disMove += stopMove;*/
        trigger.onMove += startMove;
        trigger.disMove += stopMove;
    }
    protected override void OnDisable()
    {
        base.OnDisable();
        /*        weapon.animationTrigger.onMove -= startMove;
                weapon.animationTrigger.disMove -= stopMove;*/
        trigger.onMove -= startMove;
        trigger.disMove -= stopMove;
    }

    private void startMove()
    {
        PlayerManager.instance.player.setMove(currentAttackData.vs);
    }
    private void stopMove()
    {
        PlayerManager.instance.player.stop();
    }
}

