using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Skill", menuName = "Scriptable Objects/New skill")]
public class Skill : ShopItem
{
    private int damage { get; set; }

    public Skill()
    {
        title = "DEFAULT";
        damage = 0;
        category = "SKILL";
    }

    public Skill(int damage)
    {
        this.damage = stats;
        category = "SKILL";
    }
}
