using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PWXBulletComponent : BattleComponent
{
    private Transform startTransform;
    private PWXBullet data;
    private BattleTrigger trigger;


    protected override void Awake()
    {
        base.Awake();
        startTransform = GameObject.Find("BowSlot").transform;
        data = battle.data.getData<PWXBullet>();
        trigger = GetComponentInParent<BattleTrigger>();

    }
    public void shootHandler()
    {
        GameObject bullet=GameObject.Instantiate(data.prefab, startTransform.position,Quaternion.identity);
        bullet.GetComponent<PWXBulletController>().setup(new Vector2(data.speed*player.faceDir.x,0),data.sprite,player.faceDir);
    }

    protected override void OnEnable()
    {
        base.OnEnable();
        trigger.onShoot += shootHandler;

    }
    protected override void OnDisable()
    {
        base.OnDisable();
        trigger.onShoot -= shootHandler;
    }
}
