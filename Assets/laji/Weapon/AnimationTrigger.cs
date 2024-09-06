using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationTrigger : MonoBehaviour
{
    public event Action onFinish;
    public event Action onMove;
    public event Action disMove;
    public event Action onFrame;
    public event Action disFrame;
    public event Action<AttackPhases> toPhase;

    public void finish() => onFinish?.Invoke();
    public void OnMove() => onMove?.Invoke();
    public void DisMove() => disMove?.Invoke();
    public void OnFrame() => onFrame?.Invoke();
    public void DisFrame() => disFrame?.Invoke();

    private void EnterAttackPhase(AttackPhases phase) => toPhase?.Invoke(phase);

}
