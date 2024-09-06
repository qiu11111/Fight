using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChaseState : IState
{
    private Enemy enemy;
    public EnemyChaseState(Enemy enemy)
    {
        this.enemy = enemy;
    }
    public void onEnter()
    {
        enemy.isChase = true;
        enemy.anim.SetBool("walk", true);
    }

    public void onExit()
    {
        enemy.isChase = false;
        enemy.anim.SetBool("walk", false);
    }

    public void onFixedUpdate()
    {
        enemy.move();
    }

    public void onUpdate()
    {
        if (enemy.isHurt)
            enemy.switchTo(EnemyStateType.Hurt);
        if (enemy.player != null)
        {
            if (enemy.player.position.x - enemy.transform.position.x > 0)
                enemy.sr.flipX = true;
            if (enemy.player.position.x - enemy.transform.position.x < 0)
                enemy.sr.flipX = false;
            if ((enemy.player.position - enemy.transform.position).magnitude <= enemy.attackDistance)
            {
                enemy.switchTo(EnemyStateType.Attack);
            }
        }
        else
        {
            enemy.switchTo(EnemyStateType.Idle);
        }
    }
}
