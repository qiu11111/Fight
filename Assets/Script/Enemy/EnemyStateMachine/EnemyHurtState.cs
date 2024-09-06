using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHurtState : IState
{
    private Enemy enemy;
    private float timer;
    public EnemyHurtState(Enemy enemy)
    {
        this.enemy = enemy;
    }
    public void onEnter()
    {
        enemy.anim.SetBool("hurt", true);
    }

    public void onExit()
    {
        enemy.isHurt = false;
        enemy.anim.SetBool("hurt", false);
    }

    public void onFixedUpdate()
    {
        
    }

    public void onUpdate()
    {
        timer += Time.deltaTime;
        if (timer < enemy.backTime)
        {
            enemy.rb.velocity = new Vector2(enemy.faceDir.x * -1 * enemy.attackBackV, enemy.rb.velocity.y);
        }
        else
        {
            enemy.rb.velocity = Vector2.zero;
            timer = 0;
            enemy.switchTo(EnemyStateType.Idle);
        }
    }
}
