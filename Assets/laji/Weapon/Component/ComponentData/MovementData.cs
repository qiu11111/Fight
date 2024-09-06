using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MovementData : ComponentData1<AttackMovement>
{
    public MovementData()
    {
        ComponentDependency = typeof(MovementComponent);
    }
}
