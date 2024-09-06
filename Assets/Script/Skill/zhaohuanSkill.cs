using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zhaohuanSkill : Skill
{
    [SerializeField] private GameObject HBSS;
    [SerializeField] private GameObject DPG;
    [SerializeField] private GameObject YTZZ;
    [SerializeField] private GameObject HBXG;
    private GameObject plant;
    private void Awake()
    {
        plant = HBSS;
    }
    public override void useSkill()
    {
        base.useSkill();
        GameObject zhaohuanwu=Instantiate(plant, player.transform.position,Quaternion.identity);
        zhaohuanwu.active = true;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Y))
            plant = HBSS;
        if (Input.GetKeyDown(KeyCode.U))
            plant = DPG;
        if (Input.GetKeyDown(KeyCode.I))
            plant = YTZZ;
        if (Input.GetKeyDown(KeyCode.O))
            plant = HBXG;
    }
}
