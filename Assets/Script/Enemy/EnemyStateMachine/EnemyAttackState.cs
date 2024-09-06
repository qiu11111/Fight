using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackState : IState
{
    private Enemy enemy;
    public EnemyAttackState(Enemy enemy)
    {
        this.enemy = enemy;
    }
    public void onEnter()
    {
        enemy.isAttack = true;
        enemy.anim.SetBool("attack", true);
    }

    public void onExit()
    {
        enemy.isAttack = false;
        enemy.anim.SetBool("attack", false);
    }

    public void onFixedUpdate()
    {
        enemy.rb.velocity = Vector2.zero;
    }

    public void onUpdate()
    {
        if (enemy.isHurt)
            enemy.switchTo(EnemyStateType.Hurt);
        if (enemy.player != null)
        {
            if ((enemy.player.position - enemy.transform.position).magnitude > enemy.attackDistance)
            {
                enemy.switchTo(EnemyStateType.Chase);
            }
        }
        else
        {
            enemy.switchTo(EnemyStateType.Idle);
        }
    }
}
