using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAirState : IState
{
    private Player player;
    public PlayerAirState(Player player)
    {
        this.player = player;
    }
    public void onEnter()
    {
        player.anim.SetBool("air", true);   
    }

    public void onExit()
    {
        player.anim.SetBool("air", false);
    }

    public void onFixedUpdate()
    {
        player.move();
    }

    public void onUpdate()
    {
        if (player.groundCheck())
            player.SwitchToState(PlayerStateType.Idle);
    }
}
