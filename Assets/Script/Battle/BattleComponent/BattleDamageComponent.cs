using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BattleDamageComponent : BattleComponent<BattleDamageComponentData,BattleDamageData>
{
    private BattleTrigger trigger;
    private Vector3 p = new Vector3(0, 0.2f, 0);

    protected override void Awake()
    {
        base.Awake();
        trigger = GetComponentInParent<BattleTrigger>();
    }
    private void onAttack()
    {
        Collider2D[] colliders=Physics2D.OverlapCircleAll(transform.position - p + (Vector3)player.faceDir * data.attackData[battle.currentAttackCounter].attackDistance / 2.0f, data.attackData[battle.currentAttackCounter].attackDistance / 2.0f, data.whatIsEnemy);
        foreach(Collider2D collider in colliders)
        {
            //collider.GetComponent<Enemy>().takeDamage(data.attackData[battle.currentAttackCounter].damage);

            collider.GetComponent<Enemy>().takeDamage(player.getDamage(battle.data.weapon));
        }

    }

    protected override void OnEnable()
    {
        base.OnEnable();
        trigger.onShoot += onAttack;
    }
    protected override void OnDisable()
    {
        base.OnDisable();
        trigger.onShoot -= onAttack;
    }

    private void OnDrawGizmosSelected()
    {
        if(data!=null)
            Gizmos.DrawLine(transform.position-p, transform.position + Vector3.right * data.attackData[battle.currentAttackCounter].attackDistance-p);
    }
}
