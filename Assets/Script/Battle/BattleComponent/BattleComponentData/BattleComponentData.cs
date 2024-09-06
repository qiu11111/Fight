using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class BattleComponentData 
{
    public Type componentDependency;
    
}


public  class BattleComponentData<T>:BattleComponentData where T : BattleData
{
    public T[] attackData;
}
