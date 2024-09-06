using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ComponentData1
{
    public Type ComponentDependency;
}

[Serializable]
public abstract class ComponentData1<T>:ComponentData1 where T : AttackData
{
    public T[] attackData;
}

