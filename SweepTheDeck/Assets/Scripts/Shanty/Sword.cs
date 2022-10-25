using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Sword", menuName = "Scriptable Objects/New sword")]
public class Sword : ShopItem
{
    private int damage { get; set; }

    public Sword()
    {
        title = "DEFAULT";
        damage = 100;
        category = "SWORD";
    }

    public Sword(int damage)
    {
        damage = stats;
        category = "SWORD";
    }
}
