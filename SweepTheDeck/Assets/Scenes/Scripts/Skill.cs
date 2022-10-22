using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Skill", menuName = "Scriptable Objects/New skill")]
public class Skill : ShopItem
{
    private int damage;

    public Skill()
    {
        ID = 0;
        damage = stats;
        category = "SKILL";
    }
}
