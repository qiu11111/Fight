using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrolState : IState
{
    private Enemy enemy;
    public EnemyPatrolState(Enemy enemy)
    {
        this.enemy = enemy;
    }
    public void onEnter()
    {
        enemy.isPatrol = true;
        enemy.anim.SetBool("walk", true);
    }

    public void onExit()
    {
        enemy.isPatrol = false;
        enemy.anim.SetBool("walk", false);
    }

    public void onFixedUpdate()
    {
        enemy.move();
    }

    public void onUpdate()
    {
        if (enemy.groundCheck())
        {
            enemy.sr.flipX = !enemy.sr.flipX;
            enemy.switchTo(EnemyStateType.Idle);
        }
        if (enemy.isHurt)
            enemy.switchTo(EnemyStateType.Hurt);
        if (enemy.player != null)
            enemy.switchTo(EnemyStateType.Chase);
    }

}
