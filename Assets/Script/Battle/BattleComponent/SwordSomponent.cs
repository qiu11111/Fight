using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordSomponent : BattleComponent
{
    private GameObject SwordSlot;
    private BattleComponentSword data;


    protected override void Awake()
    {
        base.Awake();
        //SwordSlot = transform.Find("SwordSlot").gameObject;
        //SwordSlot = battle.data.SwordSlot;
        SwordSlot = GameObject.Find("SwordSlot");
        data = battle.data.getData<BattleComponentSword>();
    }

    protected override void enterHandler()
    {
        base.enterHandler();
        
        SwordSlot.GetComponent<SpriteRenderer>().sprite = data.SwordSprite;
    }
    protected override void exitHandler()
    {
        base.exitHandler();
        SwordSlot.GetComponent<SpriteRenderer>().sprite = null;
    }
    //为什么下面的flipX没有用呢
    /*private void Update()
    {
        if (player.sr.flipX)
        {
            SwordSlot.GetComponent<SpriteRenderer>().flipX = true;

        }
        if (!player.sr.flipX)
        {
            SwordSlot.GetComponent<SpriteRenderer>().flipX = false;
        }
    }*/
}
