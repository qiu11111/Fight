using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackState : IState
{
    private Player player;
    private Battle battle;
    //private Weapon weapon;
    //private Weapon1 weapon;

    public PlayerAttackState(Player player)
    {
        this.player = player;
        
        //this.weapon = weapon;
        //this.weapon = weapon;
    }
    public PlayerAttackState(Player player,Battle battle)
    {
        this.player = player;
        this.battle = battle;
    }
    public void onEnter()
    {
        //weapon.enter();
        player.anim.SetBool("attack", true);
        battle.onEnter();
        battle.exit += exit;
        player.stop();
        
        /*//weapon.onExit += exit;
        weapon.onEnter();
        weapon.exit += exit;*/
    }

    public void onExit()
    {
        player.isAttack = false;
        player.anim.SetBool("attack", false);
        player.anim.runtimeAnimatorController = player.animController;
    }

    public void onFixedUpdate()
    {
        
    }

    public void onUpdate()
    {
        /*weapon.CurrentInput = player.isAttackPush;*/
        battle.CurrentInput = player.isAttackPush;
    }

    public void exit()
    {
        Debug.Log("ÍË³ö¹¥»÷×´Ì¬1");
        player.anim.runtimeAnimatorController = player.animController;
        player.SwitchToState(PlayerStateType.Idle);
    }
}
