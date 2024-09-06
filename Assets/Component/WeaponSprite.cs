using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSprite : WeaponComponent
{
    private SpriteRenderer baseSpriteRenderer;
    private SpriteRenderer weaponSpriteRenderer;

    [SerializeField] private WeaponSprites[] weaponSprites;

    private int currentWeaponSpriteIndex;


    protected override void Awake()
    {
        base.Awake();
        



        baseSpriteRenderer = transform.Find("BaseObject").GetComponent<SpriteRenderer>();
        weaponSpriteRenderer = transform.Find("WeaponObject").GetComponent<SpriteRenderer>();

        //暂时不能这样写
        //baseSpriteRenderer = weapon.baseObject.GetComponent<SpriteRenderer>();
       // weaponSpriteRenderer = weapon.weaponObject.GetComponent<SpriteRenderer>();
    }

    //用来监视baseSR变化的回调函数
    private void handleBaseSpriteChange(SpriteRenderer sr)
    {
        if (!isAttackActive)
        {
            weaponSpriteRenderer.sprite = null;
            return;
        }
        weaponSpriteRenderer.sprite = weaponSprites[weapon.CurrentAttackCounter].sprites[currentWeaponSpriteIndex];
        currentWeaponSpriteIndex++;
    }

    protected override void handlerEnter()
    {
        base.handlerEnter();
        currentWeaponSpriteIndex = 0;
    }


    protected override void OnEnable()
    {
        base.OnEnable();
        baseSpriteRenderer.RegisterSpriteChangeCallback(handleBaseSpriteChange);
        weapon.onEnter += handlerEnter;
    }
    protected override void OnDisable()
    {
        base.OnDisable();
        baseSpriteRenderer.UnregisterSpriteChangeCallback(handleBaseSpriteChange);
        weapon.onEnter -= handlerEnter;
    }

}


[Serializable]
public class WeaponSprites
{
    public Sprite[] sprites;
}
