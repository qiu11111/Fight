using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpState : IState
{
    private Player player;
    public PlayerJumpState(Player player)
    {
        this.player = player;
    }
        
    public void onEnter()
    {
        player.rb.AddForce(Vector2.up*player.jumpForce,ForceMode2D.Impulse);
        player.anim.SetBool("jump", true);
    }

    public void onExit()
    {
        player.anim.SetBool("jump", false);
        player.isJump = false;
    }

    public void onFixedUpdate()
    {
        player.move();
    }

    public void onUpdate()
    {
        if (player.rb.velocity.y <= 0)
            player.SwitchToState(PlayerStateType.Air);
    }
}
