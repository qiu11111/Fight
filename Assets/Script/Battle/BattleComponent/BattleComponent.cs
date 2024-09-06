using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleComponent : MonoBehaviour
{
    protected Battle battle;
    protected Player player;

    protected virtual void Awake()
    {
        battle = GetComponent<Battle>();
        //player = PlayerManager.instance.player;
        player = GetComponentInParent<Player>();
    }

    protected virtual void OnEnable()
    {
        battle.enter+=enterHandler;
        battle.exit += exitHandler;
    }
    protected virtual void OnDisable()
    {
        battle.enter -= enterHandler;
        battle.exit -= exitHandler;
    }
    protected virtual void enterHandler()
    {

    }
    protected virtual void exitHandler()
    {

    }
}
public class BattleComponent<T1,T2>:BattleComponent where T1:BattleComponentData<T2> where T2 : BattleData
{
    protected T1 data;
    protected T2 currentBattleData;
    protected override void Awake()
    {
        base.Awake();
        
        
    }
    protected override void enterHandler()
    {
        base.enterHandler();
        data = battle.data.getData<T1>();
        currentBattleData = data.attackData[battle.currentAttackCounter];
    }
}
