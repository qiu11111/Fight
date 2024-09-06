using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


[Serializable]
public class ZombieData 
{
    public GameObject zombie;

    [Range(0,100)]
    public int number;

}
