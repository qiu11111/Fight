using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIdleState : IState
{
    private Enemy enemy;
    private float timer;
    public EnemyIdleState(Enemy enemy)
    {
        this.enemy = enemy;
    }
    public void onEnter()
    {
        enemy.isIdle = true;
        enemy.rb.velocity = Vector2.zero;
        enemy.anim.SetBool("idle", true);
    }

    public void onExit()
    {
        enemy.isIdle = false;
        enemy.anim.SetBool("idle", false);
    }


    public void onFixedUpdate()
    {
       
    }

    public void onUpdate()
    {
        timer += Time.deltaTime;
        if (timer > enemy.idleTime)
        {
            timer = 0;
            enemy.switchTo(EnemyStateType.Patrol);
        }
        if (enemy.isHurt)
            enemy.switchTo(EnemyStateType.Hurt);
        if (enemy.player != null)
            enemy.switchTo(EnemyStateType.Chase);
            
    }
}
