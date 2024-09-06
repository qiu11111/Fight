using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AnimationEventHandler : MonoBehaviour
{
    public event Action onFinish; 

    public void animationFinishedTrigger()
    {

        onFinish?.Invoke();
    }
}
