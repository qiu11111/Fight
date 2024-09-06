using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleTrigger : MonoBehaviour
{
    public event Action onFinish;
    public event Action startMove;
    public event Action stopMove;
    public event Action onShoot;

    public event Action<BattlePhase> enterPhase;

    public void finish() => onFinish?.Invoke();
    public void StartMove() => startMove?.Invoke();
    public void StopMove() => stopMove?.Invoke();

    public void EnterPhase(BattlePhase phase) => enterPhase?.Invoke(phase);

    public void OnShoot()
    {
        onShoot?.Invoke();
    }


}
