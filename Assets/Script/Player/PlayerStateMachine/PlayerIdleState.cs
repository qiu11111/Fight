using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleState : IState
{
    private Player player;

    public PlayerIdleState(Player player)
    {
        this.player = player;
    }
    public void onEnter()
    {
        player.rb.velocity = Vector2.zero;
        player.isIdle = true;
        player.anim.SetBool("idle", true);
    }

    public void onExit()
    {
        player.isIdle = false;
        player.anim.SetBool("idle", false);
    }

    public void onFixedUpdate()
    {
        
    }

    public void onUpdate()
    {
        if (player.isWalk)
            player.SwitchToState(PlayerStateType.Walk);
        if (player.isJump)
            player.SwitchToState(PlayerStateType.Jump);
        if (player.isAttack&&!player.isAttackCool)
            player.SwitchToState(PlayerStateType.Attack);
    }
}
