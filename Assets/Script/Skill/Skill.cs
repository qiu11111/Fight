using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Skill :MonoBehaviour
{
    [SerializeField] private float coldDownTime;
    private float coldDownTimer;
    public Player player;


    private void Start()
    {
        player = PlayerManager.instance.player;
        coldDownTimer = coldDownTime;
    }
    private void Update()
    {
        coldDownTimer += Time.deltaTime;
        
    }

    public bool canBeUsed()
    {
        if (coldDownTimer >= coldDownTime)
        {
            useSkill();
            coldDownTimer = 0;
            return true;
        }
        else
        {
            Debug.Log("ººƒ‹¿‰»¥÷–");
            return false;
        }
    }

    public virtual void useSkill()
    {

    }
}
