using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BattleBowSpriteComponent : BattleComponent
{
    private BattleBowSpriteData data;
    private GameObject bowSlot;
    private BattleTrigger trigger;

    protected override void Awake()
    {
        base.Awake();
        data = battle.data.getData<BattleBowSpriteData>();
        bowSlot = GameObject.Find("BowSlot");
        trigger = GetComponentInParent<BattleTrigger>();
    }
    protected override void OnEnable()
    {
        base.OnEnable();
        trigger.enterPhase += enterPhaseHandler;

    }
    protected override void OnDisable()
    {
        base.OnDisable();
        trigger.enterPhase -= enterPhaseHandler;
        bowSlot.GetComponent<SpriteRenderer>().sprite = null;
    }
    public void enterPhaseHandler(BattlePhase Phase)
    {
        bowSlot.GetComponent<SpriteRenderer>().sprite = data.attackData.FirstOrDefault(data => data.phase == Phase).sprite;
    }
}
