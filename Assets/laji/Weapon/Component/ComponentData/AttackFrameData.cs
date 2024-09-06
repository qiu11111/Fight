using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackFrameData : ComponentData1<AttackFrame>
{
    public AttackFrameData()
    {
        ComponentDependency = typeof(AttackFrameComponent);
    }
}
