using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackFrameComponent : WeaponComponent1<AttackFrameData,AttackFrame>
{
    private AnimationTrigger trigger;

    protected override void Awake()
    {
        base.Awake();
        trigger = GetComponentInChildren<AnimationTrigger>();
    }
    protected override void OnEnable()
    {
        base.OnEnable();

    }
    protected override void OnDisable()
    {
        base.OnDisable();
    }
    public void startFrame()
    {

    }
    private void OnDrawGizmosSelected()
    {
        if (currentAttackData == null)
            return;
        if (data == null)
            return;
        Gizmos.DrawWireCube(player.transform.position + new Vector3(currentAttackData.x*player.faceDir.x, currentAttackData.y, 0), new Vector3(currentAttackData.width*player.faceDir.x, currentAttackData.height, 0));

    }
}
