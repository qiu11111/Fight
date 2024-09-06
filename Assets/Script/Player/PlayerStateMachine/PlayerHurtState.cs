using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHurtState : IState
{
    private Player player;
    private float timer;
    public PlayerHurtState(Player player)
    {
        this.player = player;
    }
    public void onEnter()
    {
        player.anim.SetBool("hurt", true);
    }

    public void onExit()
    {
        player.isHurt = false;
        player.anim.SetBool("hurt", false);
    }

    public void onFixedUpdate()
    {
        
    }

    public void onUpdate()
    {
        timer += Time.deltaTime;
        if (timer < player.backTIme)
        {
            player.rb.velocity = new Vector2(player.faceDir.x * -1 * player.backV, player.rb.velocity.y);

        }
        else
        {
            timer = 0;
           
            player.SwitchToState(PlayerStateType.Idle);
        }
    }
}
