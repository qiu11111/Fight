using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponComponent1 : MonoBehaviour
{
    protected Weapon1 weapon;
    protected bool isComponentActive;
    protected Player player;


    protected virtual void Awake()
    {
        weapon = GetComponent<Weapon1>();
        player = GetComponentInParent<Player>();
    }

    public virtual void init()
    {

    }

    protected virtual void OnEnable()
    {
        weapon.enter += enterComponent;
        weapon.exit += exitComponent;
    }

    protected virtual void OnDisable()
    {
        weapon.enter -= enterComponent;
        weapon.exit -= exitComponent;
    }
    protected virtual void enterComponent()
    {
        isComponentActive = true;
    }
    protected virtual void exitComponent()
    {
        isComponentActive = false;
    }
}

public abstract class WeaponComponent1<T1, T2> :WeaponComponent1 where T1:ComponentData1<T2> where T2 : AttackData
{
    public T1 data;
    public T2 currentAttackData;

    public override void init()
    {
        base.Awake();
        data = weapon.weaponComponentDataSO.getData<T1>();
        
    }
    protected override void enterComponent()
    {
        base.enterComponent();
        currentAttackData = data.attackData[weapon.currentAttackCounter];
    }
}
