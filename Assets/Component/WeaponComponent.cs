using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;

public abstract class WeaponComponent : MonoBehaviour
{
    protected Weapon weapon;

    protected bool isAttackActive;

    protected virtual void Awake()
    {
        weapon = GetComponent<Weapon>();
    }

    protected virtual void handlerEnter()
    {
        isAttackActive = true;
    }
    protected virtual void HandleExit()
    {
        isAttackActive = false;
    }

    protected virtual void OnEnable()
    {
        weapon.onEnter += handlerEnter;
        weapon.onExit += HandleExit;
    }

    protected virtual void OnDisable()
    {
        weapon.onEnter -= handlerEnter;
        weapon.onExit -= HandleExit;
    }
}
