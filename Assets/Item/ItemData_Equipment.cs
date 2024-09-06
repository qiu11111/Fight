using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EquipmentType
{
    Weapon,
    Clothe,
    Sword,
    Bow,
    Staff
}

[CreateAssetMenu(fileName ="New Item",menuName ="Equipment")]
public class ItemData_Equipment : ItemData
{
    public EquipmentType equipmentType;

    public float damage;
    public float blood;
    public float jumpForce;
    public int bowDamage;
    public int staffDamage;
    public int swordDamage;

    public void add()
    {
        Player player = PlayerManager.instance.player;
        player.damage += damage;
        player.maxBlood += blood;
        player.jumpForce += jumpForce;
        player.bowDamage += bowDamage;
        player.staffDamage += staffDamage;
        player.swordDamage += swordDamage;
    }
    public void remove()
    {
        Player player = PlayerManager.instance.player;
        player.damage -= damage;
        player.maxBlood -= blood;
        player.jumpForce -= jumpForce;
        player.bowDamage -= bowDamage;
        player.staffDamage -= staffDamage;
        player.swordDamage -= swordDamage;
    }
}
