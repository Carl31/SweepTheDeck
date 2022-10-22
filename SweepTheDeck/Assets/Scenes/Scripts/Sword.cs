using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Sword", menuName = "Scriptable Objects/New sword")]
public class Sword : ShopItem
{
    private int damage;

    public Sword()
    {
        ID = 0;
        damage = stats;
        category = "SWORD";
    }
}
