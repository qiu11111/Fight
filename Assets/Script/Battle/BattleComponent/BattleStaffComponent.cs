using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BattleStaffComponent : BattleComponent
{
    private GameObject location;
    private BattleStaffSpriteData data;
    private BattleTrigger trigger;
    private GameObject StaffBullet;

    private GameObject staffBullet;
    private StaffBulletController bulletController;
    protected override void Awake()
    {
        base.Awake();
        location = GameObject.Find("SwordSlot");
        trigger = GetComponentInParent<BattleTrigger>();
        data = battle.data.getData<BattleStaffSpriteData>();
        StaffBullet = data.bullet;



    }

    protected override void enterHandler()
    {
        base.enterHandler();
    }

    protected override void exitHandler()
    {
        base.exitHandler();
        location.GetComponent<SpriteRenderer>().sprite = null;
    }
    public void enterStaffPhase(BattlePhase Phase)
    {
        location.GetComponent<SpriteRenderer>().sprite = data.sprite;
        if (Phase == BattlePhase.Pre)
        {
            staffBullet=GameObject.Instantiate(StaffBullet, transform.position + new Vector3(0, 5, 0), Quaternion.identity);
            bulletController = staffBullet.GetComponent<StaffBulletController>();
            bulletController.isPre = true;
        }
        if (Phase == BattlePhase.Action)
        {
            bulletController.shoot(player.faceDir);
        }
    }

    protected override void OnEnable()
    {
        base.OnEnable();
        trigger.enterPhase += enterStaffPhase;
    }
    protected override void OnDisable()
    {
        base.OnDisable();
        trigger.enterPhase -= enterStaffPhase;
    }
}
