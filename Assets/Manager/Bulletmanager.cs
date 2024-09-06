using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bulletmanager : MonoBehaviour
{
    public static Bulletmanager instance;

    public GameObject hbssBullet;
    public GameObject DPGBullet;
    public GameObject HBXGBullet;

    private void Awake()
    {
        if (instance != null)
            Destroy(gameObject);
        instance = this;
    }



}
