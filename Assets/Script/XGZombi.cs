using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XGZombi : Enemy
{
    public override void getdie()
    {
        GetComponent<DropItem>().generateDrops();
        base.getdie();
    }
}
