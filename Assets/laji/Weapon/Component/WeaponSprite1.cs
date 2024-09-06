using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class WeaponSprite1 : WeaponComponent1<AttackSpriteData1,AttackSprite>
{
    private SpriteRenderer BaseSR;
    private SpriteRenderer WeaponSR;
    private int index;
    private AnimationTrigger eventHandler;
    private Sprite[] currentPhaseSprites;

    protected override void Awake()
    {
        base.Awake();
        BaseSR = transform.Find("BaseObject").GetComponent<SpriteRenderer>();
        WeaponSR = transform.Find("WeaponObject").GetComponent<SpriteRenderer>();
        eventHandler = GetComponentInChildren<AnimationTrigger>();
        eventHandler.toPhase += handleEnterAttackPhase;

        
    }

    private void handleEnterAttackPhase(AttackPhases phase)
    {
        index = 0;
        currentPhaseSprites = currentAttackData.phaseSprites.FirstOrDefault(data => data.Phase == phase).sprites;
        print(currentAttackData.phaseSprites.FirstOrDefault(data => data.Phase == phase).Phase);
    }

    private void spriteChangeHandler(SpriteRenderer sr)
    {
        if (!isComponentActive)
        {
            WeaponSR.sprite = null;
            return;
        }
        //引入动作阶段

        //WeaponSR.sprite = currentAttackData.sprites[index];
        WeaponSR.sprite = currentPhaseSprites[index];
        index++;

    }
    /*    private void enterComponent()
        {
            index = 0;
            isComponentActive = true;
        }
        private void exitComponent()
        {
            isComponentActive = false;
        }*/
    protected override void enterComponent()
    {
        base.enterComponent();
        index = 0;
    }
    protected override void OnEnable()
    {
        base.OnEnable();
        BaseSR.RegisterSpriteChangeCallback(spriteChangeHandler);
/*        weapon.enter += enterComponent;
        weapon.exit += exitComponent;*/
    }
    protected override void OnDisable()
    {
        base.OnDisable();
        BaseSR.UnregisterSpriteChangeCallback(spriteChangeHandler);
        eventHandler.toPhase -= handleEnterAttackPhase;
        /*        weapon.enter -= enterComponent;
                weapon.exit -= exitComponent;*/
    }
    private void Update()
    {
        if (player.sr.flipX)
        {
            BaseSR.flipX = true;
            WeaponSR.flipX = true;
        }
        else
        {
            BaseSR.flipX = false;
            WeaponSR.flipX = false;
        }
       
    }
}
