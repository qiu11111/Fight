using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class PWXBullet : BattleComponentData
{
    public Sprite sprite;
    public float speed;
    public GameObject prefab;
    public PWXBullet()
    {
        componentDependency = typeof(PWXBulletComponent);
    }
}
